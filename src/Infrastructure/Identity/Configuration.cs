using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity
{
    public static class Configuration
    {
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256())},
                    //ClientName = "Web",
                    //AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    {
                        "WebAPI",
                        "Api",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    //AllowedCorsOrigins =
                    //{
                    //    //"https://localhost:7001"
                    //}
                    
                    //RequireClientSecret = false,
                    //RequirePkce = true,
                    //RedirectUris =
                    //{
                    //    "http://.../signin-oidc"
                    //},
                    //AllowedCorsOrigins =
                    //{
                    //    "http://..."
                    //},
                    //PostLogoutRedirectUris =
                    //{
                    //    "http://.../signout-oidc"
                    //},
                    //AllowedScopes =
                    //{
                    //    IdentityServerConstants.StandardScopes.OpenId,
                    //    IdentityServerConstants.StandardScopes.Profile,
                    //    "WebAPI"
                    //},
                    //AllowAccessTokensViaBrowser = true
                },
                new Client
                {
                    ClientId = "client_id_mvc",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        "WebAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    RedirectUris = { "https://localhost:5001/signin-oidc" },

                    RequireConsent = false,

                    //AlwaysIncludeUserClaimsInIdToken = true

                }
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("WebAPI", "Web API", new [] { JwtClaimTypes.Name})
                {
                    Scopes =
                    {
                        "WebAPI",
                        "Api"
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                //new ApiScope("Api", "Web API")
                new ApiScope("Api",new List<string>
                {
                    "WebAPI",
                    "Api"
                })
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        
    }
}
