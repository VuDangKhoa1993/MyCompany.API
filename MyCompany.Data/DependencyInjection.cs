using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyCompany.Core.Services;

namespace MyCompany.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyCompanyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("MyCompany.Data"));
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Company Api", Version = "v1" });
            });
            return services;
        }

        public static IServiceCollection AddAppsettingConfigs(this IServiceCollection services)
        {
            services.Configure<>
        }

    }
}
