using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Zoe.IdentityAccess.Api.Controllers.Responses;
using Zoe.IdentityAccess.Api.LocalizationResources;

namespace Zoe.IdentityAccess.Api.Configurations
{
    public static class GlobalExceptionHandlerConfig
    {
        public static IApplicationBuilder UseGlobalExceptionHandlerConfig(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                return app;
            }

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api"))
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";

                        var factory = app.ApplicationServices.GetService<IStringLocalizerFactory>();
                        var type = typeof(SharedResource);
                        var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                        var localizer = factory.Create("SharedResource", assemblyName.Name);

                        await context.Response.WriteAsync(RenderStringErrorResponse(localizer));
                    }

                    context.Response.Redirect("/Error");
                });
            });

            return app;
        }

        private static string RenderStringErrorResponse(IStringLocalizer localizer)
        {
            return JsonSerializer.Serialize(new ResponseBase<object>
            {
                Succeeded = false,
                Data = null,
                Errors = new List<ResponseError>
                {
                    new ResponseError
                    {
                        Code = "Server",
                        Description = localizer["DEFAULT_API_ERROR"].Value
                    }
                }
            });
        }
    }
}
