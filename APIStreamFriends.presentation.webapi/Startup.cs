﻿using APIStreamFriends.infra.CrossCutting.IoC;
using APIStreamFriends.presentation.webapi.Swagger;
using APITransacao.netcore.presentation.webapi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace APIStreamFriends.presentation.webapi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();

            //Carregar configurações do token
            var tokenConfigurations = new TokenConfigurations();

            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("Jwt"))
                    .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            //Validação do token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            //Configuração do Swagger
            services.ConfigureSwaggerGen(x =>
            {
                x.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                x.OperationFilter<ProducesOperatioFilter>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API Stream Friends",
                    Description = "Faça download de videos",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Rafael Dias",
                        Email = string.Empty,
                        Url = "https://github.com/rafaeldias97"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.OperationFilter<ExamplesOperationFilter>();
            });

            //Auto mapper
            services.AddAutoMapper();

            //Injeções de dependencia 
            NativeInjectorBootStrapper.RegisterServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"../swagger/v1/swagger.json", "apistreamfriends");
            });

            app.UseCors(b => b.WithOrigins("*")
              .AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
