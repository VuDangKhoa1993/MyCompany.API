using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyCompany.Core.Repositories;
using MyCompany.Core.Services;
using MyCompany.Data.Repository;
using MyCompany.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.API.Helpers
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
        public static IServiceCollection AddRepositoriesDenpendencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddNewtonsoftJson(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            return services;
        }

        public static IServiceCollection AddAuthenticateDependency(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);

            // config
            
        }

    }
}
