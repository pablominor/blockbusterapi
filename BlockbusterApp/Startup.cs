using System;
using System.Collections.Generic;
using System.Text;
using BlockbusterApp.src.Application.Event.User;
using BlockbusterApp.src.Application.UseCase.Category.Create;
using BlockbusterApp.src.Application.UseCase.Category.FindById;
using BlockbusterApp.src.Application.UseCase.Category.Response;
using BlockbusterApp.src.Application.UseCase.Country.FindByCode;
using BlockbusterApp.src.Application.UseCase.Country.Response;
using BlockbusterApp.src.Application.UseCase.Email.SendUserWelcome;
using BlockbusterApp.src.Application.UseCase.Product.Create;
using BlockbusterApp.src.Application.UseCase.Token.Create;
using BlockbusterApp.src.Application.UseCase.Token.Delete;
using BlockbusterApp.src.Application.UseCase.Token.Response;
using BlockbusterApp.src.Application.UseCase.Token.Update;
using BlockbusterApp.src.Application.UseCase.User.FindByEmalAndPassword;
using BlockbusterApp.src.Application.UseCase.User.FindByFilter;
using BlockbusterApp.src.Application.UseCase.User.FindById;
using BlockbusterApp.src.Application.UseCase.User.Response;
using BlockbusterApp.src.Application.UseCase.User.SignUP;
using BlockbusterApp.src.Application.UseCase.User.Update;
using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CategoryAggregate.Service;
using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.CountryAggregate.Service;
using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.ProductAggregate.Service;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Persistance.Repository;
using BlockbusterApp.src.Infraestructure.Service.Category;
using BlockbusterApp.src.Infraestructure.Service.Product;
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
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase.URL;
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

            LoadApplicacionDependencies(services);
            LoadDomainDependencies(services);
            LoadInfraestructureDependencies(services);

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
            GetUsersUseCase getUsersUseCase = serviceProvider.GetService<GetUsersUseCase>();
            FindUserByIdUseCase getUserPersonalDataUseCase = serviceProvider.GetService<FindUserByIdUseCase>();
            CreateTokenUseCase createTokenUseCase = serviceProvider.GetService<CreateTokenUseCase>();
            FindUserByEmailAndPasswordUseCase findUserByEmailAndPasswordUseCase = serviceProvider.GetService<FindUserByEmailAndPasswordUseCase>();
            FindCountryByCodeUseCase findCountryByCodeUseCase = serviceProvider.GetService<FindCountryByCodeUseCase>();
            UpdateTokenUseCase updateTokenUseCase = serviceProvider.GetService<UpdateTokenUseCase>();
            UpdateUserUseCase updateUserUseCase = serviceProvider.GetService<UpdateUserUseCase>();
            DeleteTokenUseCase deleteTokenUseCase = serviceProvider.GetService<DeleteTokenUseCase>();
            CreateCategoryUseCase createCategoryUseCase = serviceProvider.GetService<CreateCategoryUseCase>();
            CreateProductUseCase createProductUseCase = serviceProvider.GetService<CreateProductUseCase>();
            FindCategoryByIdUseCase findCategoryByIdUseCase = serviceProvider.GetService<FindCategoryByIdUseCase>();

            useCaseBus.Subscribe(signUpUserUseCase);
            useCaseBus.Subscribe(sendUserWelcomeEmailUseCase);
            useCaseBus.Subscribe(getUsersUseCase);
            useCaseBus.Subscribe(getUserPersonalDataUseCase);
            useCaseBus.Subscribe(createTokenUseCase);
            useCaseBus.Subscribe(findUserByEmailAndPasswordUseCase);
            useCaseBus.Subscribe(findCountryByCodeUseCase);
            useCaseBus.Subscribe(updateTokenUseCase);
            useCaseBus.Subscribe(updateUserUseCase);
            useCaseBus.Subscribe(deleteTokenUseCase);
            useCaseBus.Subscribe(createCategoryUseCase);
            useCaseBus.Subscribe(createProductUseCase);
            useCaseBus.Subscribe(findCategoryByIdUseCase);

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

        private void LoadApplicacionDependencies(IServiceCollection services)
        {
            LoadApplicationUseCases(services);
            LoadApplicationConverters(services);          
            services.AddScoped<SendWelcomeEmailWhenUserSignedUpEventHandler>();
            services.AddScoped<WelcomeEmailModelFactory>();            
        }

        private void LoadDomainDependencies(IServiceCollection services)
        {            
            services.AddScoped<SignUpUserValidator>();
            services.AddScoped<UserFinder>();
            services.AddScoped<CountryFinder>();
            services.AddScoped<CategoryFinder>();
            services.AddScoped<CreateCategoryValidator>();
            services.AddScoped<CreateProductValidator>();

            LoadDomainRepositoriesDependencies(services);
            LoadDomainFactoriesDependencies(services);
        }

        private void LoadInfraestructureDependencies(IServiceCollection services)
        {
            services.AddScoped<IHashing, DefaultHashing>();
            
            services.AddSingleton<BlockbusterContext>();
            services.AddScoped<IEventProvider, EventProvider>();
            services.AddScoped<IDomainEventPublisher, DomainEventPublisherSync>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IMailer, SMTPMailer>();

            services.AddScoped<IJWTEncoder, JWTEncoder>();
            services.AddScoped<TokenAdapter>();
            services.AddScoped<TokenFacade>();
            services.AddScoped<TokenTranslator>();

            services.AddSingleton<IUseCaseBus, UseCaseBus>();

            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IUrlProvider, UrlProvider>();
            services.AddHttpContextAccessor();

            LoadInfraRequestsDependencies(services);
            LoadInfraResponsesDependencies(services);
            LoadInfraMiddlewareDependencies(services);
        }

        private void LoadDomainRepositoriesDependencies(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        private void LoadDomainFactoriesDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<ITokenFactory, TokenFactory>();
            services.AddScoped<ICategoryFactory, CategoryFactory>();
            services.AddScoped<IProductFactory, ProductFactory>();
        }

        private void LoadInfraRequestsDependencies(IServiceCollection services)
        {
            services.AddScoped<IRequest, SignUpUserRequest>();
            services.AddScoped<IRequest, CreateTokenRequest>();
            services.AddScoped<IRequest, GetUsersRequest>();
            services.AddScoped<IRequest, FindUserByIdRequest>();
            services.AddScoped<IRequest, FindCountryByCodeRequest>();
            services.AddScoped<IRequest, UpdateTokenRequest>();
            services.AddScoped<IRequest, UpdateUserRequest>();
            services.AddScoped<IRequest, DeleteTokenRequest>();
            services.AddScoped<IRequest, CreateCategoryRequest>();
            services.AddScoped<IRequest, CreateProductRequest>();
            services.AddScoped<IRequest, FindCategoryByIdRequest>();
        }

        private void LoadInfraResponsesDependencies(IServiceCollection services)
        {
            services.AddScoped<IResponse, CreateTokenResponse>();
            services.AddScoped<IResponse, FindUserResponse>();
            services.AddScoped<IResponse, EmptyResponse>();
        }

        private void LoadInfraMiddlewareDependencies(IServiceCollection services)
        {
            services.AddScoped<UseCaseMiddleware>();
            services.AddSingleton<TransactionMiddleware>();
            services.AddScoped<EventDispatcherSyncMiddleware>();
            services.AddScoped<ExceptionMiddleware>();
        }

        private void LoadApplicationUseCases(IServiceCollection services)
        {
            services.AddScoped<SignUpUserUseCase>();
            services.AddScoped<SendUserWelcomeEmailUseCase>();
            services.AddScoped<CreateTokenUseCase>();
            services.AddScoped<GetUsersUseCase>();
            services.AddScoped<FindUserByIdUseCase>();
            services.AddScoped<FindUserByEmailAndPasswordUseCase>();
            services.AddScoped<FindCountryByCodeUseCase>();
            services.AddScoped<UpdateTokenUseCase>();
            services.AddScoped<UpdateUserUseCase>();
            services.AddScoped<DeleteTokenUseCase>();
            services.AddScoped<CreateCategoryUseCase>();
            services.AddScoped<CreateProductUseCase>();
            services.AddScoped<FindCategoryByIdUseCase>();
        }

        private void LoadApplicationConverters(IServiceCollection services)
        {
            services.AddScoped<ExceptionConverter>();
            services.AddScoped<EmptyResponseConverter>();
            services.AddScoped<TokenConverter>();
            services.AddScoped<GetUsersConverter>();
            services.AddScoped<FindUserResponseConverter>();
            services.AddScoped<CountryResponseConverter>();
            services.AddScoped<CategoryResponseConverter>();
        }
    }
}
