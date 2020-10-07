using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class DocumentationConfig
    {
        public static IServiceCollection AddDocumentationConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Version = description.ApiVersion.ToString(),
                        Title = $"IdentityAccess Api {description.GroupName}",
                        Description = description.IsDeprecated
                            ? "IdentityAccess Api - DEPRECATED"
                            : "IdentityAccess Api"
                    });
                }

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseDocumentationConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"IdentityAccess Api {description.GroupName}");
                    options.RoutePrefix = "docs";
                }
            });

            return app;
        }
    }
}
