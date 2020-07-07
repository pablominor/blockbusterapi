using System;
using System.Collections.Generic;
using System.Text;
using BlockbusterApp.src.Application.Event.User;
using BlockbusterApp.src.Application.UseCase.Email;
using BlockbusterApp.src.Application.UseCase.Token;
using BlockbusterApp.src.Application.UseCase.User.SignUP;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Persistance.Repository;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Infraestructure.Service.Mailer;
using BlockbusterApp.src.Infraestructure.Service.Token;
using BlockbusterApp.src.Infraestructure.Service.User;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain.Event;
using BlockbusterApp.src.Shared.Infraestructure.Bus.Event;
using BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware;
using BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware.Exception;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using BlockbusterApp.src.Shared.Infraestructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace BlockbusterApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var appSettingsSection = Configuration.GetSection("AppSettings");
            var secret = Configuration.GetValue<string>("AppSettings:Secret");
            var key = Encoding.ASCII.GetBytes(secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddOptions();

            services.AddDbContextPool<BlockbusterContext>(options => options
                .UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            //Application
            services.AddScoped<UserConverter>();
            services.AddScoped<SignUpUserUseCase>();
            services.AddScoped<SendUserWelcomeEmailUseCase>();
            services.AddScoped<SendWelcomeEmailWhenUserSignedUpEventHandler>();
            services.AddScoped<WelcomeEmailConverter>();
            services.AddScoped<ExceptionConverter>();

            services.AddScoped<TokenConverter>();
            services.AddScoped<CreateTokenUseCase>();

            //Domain
            services.AddScoped<IUserFactory,UserFactory>();
            services.AddScoped<SignUpUserValidator>();

            services.AddScoped<ITokenFactory,TokenFactory>();

            //Infra
            services.AddScoped<IHashing,DefaultHashing>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddSingleton<BlockbusterContext>();
            services.AddScoped<IEventProvider, EventProvider>();
            services.AddScoped<IDomainEventPublisher, DomainEventPublisherSync>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IMailer, SendgridMailer>();

            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ITokenFactory,TokenFactory>();
            services.AddScoped<IJWTEncoder,JWTEncoder>();
            services.AddScoped<TokenAdapter>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<IUseCaseBus,UseCaseBus>();

            services.AddScoped<IRequest,SignUpUserRequest>();
            services.AddScoped<IRequest, CreateTokenRequest>();

            services.AddScoped<IResponse,SignUpUserResponse>();            
            services.AddScoped<IResponse, CreateTokenResponse>();

            services.AddScoped<UseCaseMiddleware>();
            services.AddSingleton<TransactionMiddleware>();
            services.AddScoped<EventDispatcherSyncMiddleware>();
            services.AddScoped<ExceptionMiddleware>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
            services.AddSwaggerGen(
                options =>
                {
                    options.AddSecurityDefinition("oauth2", new ApiKeyScheme
                    {
                        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                        In = "header",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                    options.OperationFilter<SecurityRequirementsOperationFilter>();

                    var provider = services.BuildServiceProvider()
                                        .GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(
                            description.GroupName,
                            new Info()
                            {
                                Title = $"Sample API {description.ApiVersion}",
                                Version = description.ApiVersion.ToString()
                            });
                    }
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider, IServiceProvider serviceProvider)
        {

            IUseCaseBus useCaseBus = serviceProvider.GetService<IUseCaseBus>();
            SignUpUserUseCase signUpUserUseCase = serviceProvider.GetService<SignUpUserUseCase>();
            SendUserWelcomeEmailUseCase sendUserWelcomeEmailUseCase = serviceProvider.GetService<SendUserWelcomeEmailUseCase>();
            useCaseBus.Subscribe(signUpUserUseCase);
            useCaseBus.Subscribe(sendUserWelcomeEmailUseCase);

            List<IMiddlewareHandler> middlewareHandlers = new List<IMiddlewareHandler>
            {
                serviceProvider.GetService<TransactionMiddleware>(),
                serviceProvider.GetService<EventDispatcherSyncMiddleware>(),
                serviceProvider.GetService<ExceptionMiddleware>()
            };

            useCaseBus.SetMiddlewares(middlewareHandlers);

            IEventBus eventBus = serviceProvider.GetService<IEventBus>();
            eventBus.Subscribe(serviceProvider.GetService<SendWelcomeEmailWhenUserSignedUpEventHandler>(), "user_signed_up");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
           
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
            app.UseCors("AllowAllOrigins");

            app.UseMvc();
        }
    }
}
