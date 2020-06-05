using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyCompany.Core.Repositories;
using MyCompany.Core.Services;
using MyCompany.Data;
using MyCompany.Data.Repository;
using MyCompany.Service.Services;
using Microsoft.OpenApi.Models;
using AutoMapper;
using MyCompany.API.Helpers;

namespace MyCompany.API
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
            services.AddPersistence(Configuration)
                    .AddSwagger()
                    .AddServiceDependencies()
                    .AddRepositoriesDenpendencies()
                    .AddNewtonsoftJson();

            services.AddAutoMapper(typeof(Startup));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                //app.UseExceptionHandler("/Error");
            }

            app.Use(async (context, next) =>
            {
                await next.Invoke();
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Company API");
                c.RoutePrefix = string.Empty;

            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
