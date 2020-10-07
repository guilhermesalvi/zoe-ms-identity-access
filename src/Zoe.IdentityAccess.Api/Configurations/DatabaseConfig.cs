using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zoe.IdentityAccess.Api.Data;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfig(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<IdentityAccessDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
