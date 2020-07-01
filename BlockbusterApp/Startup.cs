﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockbusterApp.src.Application.UseCase;
using BlockbusterApp.src.Domain;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infraestructure.Persistance.Repository;
using BlockbusterApp.src.Infraestructure.Service.Hashing;
using BlockbusterApp.src.Infraestructure.Service.User;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            services.AddDbContextPool<BlockbusterContext>(options => options
                .UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            //Application
            services.AddScoped<UserConverter>();
            services.AddScoped<IUseCase, SignUpUserUseCase>();

            //Domain
            services.AddScoped<IUserFactory,UserFactory>();
            services.AddScoped<SignUpUserValidator>();

            //Infra
            services.AddScoped<IHashing,DefaultHashing>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddSingleton<BlockbusterContext>();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<IUseCaseBus,UseCaseBus>();
            services.AddScoped<IRequest,SignUpUserRequest>();
            services.AddScoped<IResponse,SignUpUserResponse>();

            services.AddScoped<UseCaseMiddleware>();
            services.AddSingleton<TransactionMiddleware>();


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
            IUseCase signUpUserUseCase = serviceProvider.GetService<IUseCase>();
            useCaseBus.Subscribe(signUpUserUseCase);

            List<IMiddlewareHandler> middlewareHandlers = new List<IMiddlewareHandler>
            {
                serviceProvider.GetService<TransactionMiddleware>()
            };

            useCaseBus.SetMiddlewares(middlewareHandlers);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
           
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
