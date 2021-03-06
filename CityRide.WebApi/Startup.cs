﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using FluentValidation.AspNetCore;

using CityRide.Bootstrap.Bike;
using CityRide.Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoMapper;
using CityRide.Bootstrap.Identity;
using MassTransit;
using System;

namespace CityRide.WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CityRide apis", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new[] { "readAccess", "writeAccess" }
                    }
                });
            });

            services.AddCors();

            services.AddMvc()
                    .AddFluentValidation(); 
            
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        var host = cfg.Host(Configuration.GetSection("RabbitMq:Endpoint").Value, h =>
                        {
                            h.Username(Configuration.GetSection("RabbitMq:Username").Value);
                            h.Password(Configuration.GetSection("RabbitMq:Password").Value);
                        });
                    });

            services.AddSingleton<IPublishEndpoint>(bus);
            services.AddSingleton<ISendEndpointProvider>(bus);
            services.AddSingleton<IBus>(bus);

            bus.Start();

            ConfigureMapper(services);

            services.RegisterInfrastructure();

            services.RegisterBikeModule();
            services.RegisterIdentityModule(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CityRide apis");
                });

            app.UseHttpsRedirection();
            app.UseRouting(); 
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private void ConfigureMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.RegisterBikeModuleProfiler();
                cfg.RegisterIdentityModuleProfiler();
            });

            services.AddSingleton(typeof(IMapper), config.CreateMapper());
        }
    }
}