using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zoe.IdentityAccess.Api.Configurations;

namespace Zoe.IdentityAccess.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatRConfig();
            services.AddNotificationsConfig();
            services.AddVersioningConfig();
            services.AddDocumentationConfig();
            services.AddLocalizationConfig();
            services.AddBehaviorsConfig();
            services.AddPresentersConfig();
            services.AddDatabaseConfig(Configuration);
            services.AddIdentityConfig();
            services.AddIdentityServerConfig(Configuration);
            services.AddControllersConfig();
            services.AddRazorPagesConfig();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseLocalizationConfig();
            app.UseGlobalExceptionHandlerConfig(env);
            app.UseDocumentationConfig();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServerConfig(env);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
