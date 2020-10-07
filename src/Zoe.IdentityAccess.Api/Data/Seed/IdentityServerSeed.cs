using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Zoe.IdentityAccess.Api.Data.Seed
{
    public static class IdentityServerSeed
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            if (!context.Clients.Any())
            {
                foreach (var client in Config.Clients)
                {
                    context.Clients.Add(client.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.IdentityResources)
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in Config.ApiScopes)
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }
        }

        #region Data

        public static class Config
        {
            public static IEnumerable<IdentityResource> IdentityResources
            {
                get
                {
                    return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                };
                }
            }

            public static IEnumerable<ApiScope> ApiScopes
            {
                get
                {
                    return new List<ApiScope>
                {
                    new ApiScope("members", "Members Api")
                };
                }
            }

            public static IEnumerable<Client> Clients
            {
                get
                {
                    return new List<Client>
                {
                    new Client
                    {
                        ClientId = "webclient",
                        RequireClientSecret = false,
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        AllowOfflineAccess = true,
                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "members"
                        }
                    }
                };
                }
            }
        }

        #endregion
    }
}
