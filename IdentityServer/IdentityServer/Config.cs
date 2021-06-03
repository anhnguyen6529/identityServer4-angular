using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using System.Security.Claims;
using System.Text.Json;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static List<TestUser> Users
        {
            get
            {
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "alice",
                        Password = "alice",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                            new Claim(JwtClaimTypes.Role, "admin"),
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "bob",
                        Password = "bob",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                            new Claim(JwtClaimTypes.Role, "user"),
                        }
                    }
                };
            }
        }

        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("restAPI.read"),
                new ApiScope("restAPI.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("restAPI")
                {
                    Scopes = new List<string> { "restAPI.read", "restAPI.write"},
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "interactive1",
                    ClientSecrets = {new Secret("SuperSecretPassword1".Sha256())},
                    
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = {"http://localhost:4200/home"},
                    FrontChannelLogoutUri = "http://localhost:4200/home",
                    PostLogoutRedirectUris = {"http://localhost:4200/home"},
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    
                    AllowOfflineAccess = true,
                    AllowedScopes = {"openid", "profile", "restAPI.read"},
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false,
                    AllowAccessTokensViaBrowser = true,
                },

                new Client
                {
                    ClientId = "interactive2",
                    ClientSecrets = {new Secret("SuperSecretPassword2".Sha256())},

                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = {"http://localhost:59650/home"},
                    FrontChannelLogoutUri = "http://localhost:59650/home",
                    PostLogoutRedirectUris = {"http://localhost:59650/home"},
                    AllowedCorsOrigins = {"http://localhost:59650"},

                    AllowOfflineAccess = true,
                    AllowedScopes = {"openid", "profile", "restAPI.write"},
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false,
                    AllowAccessTokensViaBrowser = true,
                },
            };
    }
}
