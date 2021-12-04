using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql;
using CarnageApi.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarnageApi.Core.Interfaces;
using CarnageApi.Core.Services;
using EntityConfigurationBase;
using System.Configuration;
using IFourty5MillionContext = CarnageApi.Infrastructure.Database.IFourty5MillionContext;
using MySql.Data.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.IdentityModel.Tokens.Jwt;

namespace CarnageApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string mysqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<Fourty5MillionContext>(options => options.UseMySql(mysqlConnectionStr));

            services.AddDbContext<Fourty5MillionContext>(options => options
                .UseSqlServer(mysqlConnectionStr));

            services.AddControllers();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddScoped<IFourty5MillionContext, Fourty5MillionContext>();
            services.AddScoped<IFourty5MillionUnitOfWork, Fourty5MillionUnitOfWork>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthInfo, AuthInfo>();

            services.AddCors(options => 
            {



                options.AddPolicy("AllowAllHeaders", builder => builder.AllowAnyOrigin()
                                                                .AllowAnyHeader()
                                                                .AllowAnyMethod()
                                                                .AllowAnyOrigin()
                                                                .WithOrigins("https://www.carnagehosting.com",
                                                                             "https://localhost")
                                                                .SetIsOriginAllowedToAllowWildcardSubdomains());


            });
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation  
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "JWT Token Authentication API",
                    Description = "ASP.NET Core 3.1 Web API"
                });
                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarnageApi v1"));
            }

            app.UseCors("AllowAllHeaders");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
