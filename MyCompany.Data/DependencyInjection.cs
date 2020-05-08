using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

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

            //services.AddScoped<MyCompanyDbContext>(provider => provider.GetService<MyCompanyDbContext>());
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
    }
}
