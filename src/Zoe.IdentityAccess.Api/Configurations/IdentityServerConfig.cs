using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Zoe.IdentityAccess.Api.Data.Seed;
using Zoe.IdentityAccess.Api.Models;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class IdentityServerConfig
    {
        public static IServiceCollection AddIdentityServerConfig(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                options.EmitStaticAudienceClaim = true;
            })
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddAspNetIdentity<User>()
            .AddDeveloperSigningCredential();

            return services;
        }

        public static IApplicationBuilder UseIdentityServerConfig(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                IdentityServerSeed.InitializeDatabase(app);
            }

            app.UseIdentityServer();

            return app;
        }
    }
}
