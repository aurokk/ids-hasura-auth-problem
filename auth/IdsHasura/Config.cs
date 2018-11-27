using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdsHasura
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(
                    "api1",
                    "My API",
                    new[]
                    {
                        JwtClaimTypes.Subject,
                        "rulebook_claims"
                    }
                ),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"api1"},
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim(
                            "rulebook_claims",
                            "{\"x-hasura-allowed-roles\":[\"user\"],\"x-hasura-default-role\":\"user\",\"x-hasura-user-id\":\"4d4064d1-c33f-423b-b262-f32ea16964aa\"}",
                            IdentityServerConstants.ClaimValueTypes.Json
                        ),
                    }
                },
            };
        }
    }
}