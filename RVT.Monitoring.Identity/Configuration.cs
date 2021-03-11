using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.Identity
{
    public static class Configuration
    {
        public static string IDENTITYDB_CONNECION = "Server=DESKTOP-GDI15RS\\SQLEXPRESS;Database=RVT.Monitoring.Identity;Trusted_Connection=True;MultipleActiveResultSets=true";
        public static string IDENTITY_USERS_CONNECION = "Server=DESKTOP-GDI15RS\\SQLEXPRESS;Database=RVT.Monitoring.Identity.User;Trusted_Connection=True;MultipleActiveResultSets=true";
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
                 {
                     new ApiResource("api1", "My API")
             };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
    {
        new Client
        {
            ClientId = "ClientAPI",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("ClientAPI".Sha256())
            },              

            // scopes that client has access to
            AllowedScopes = { "api1" }
        },
        new Client
        {
            ClientId = "ClientBlazor",
            AllowedGrantTypes = GrantTypes.Code,
            RequireClientSecret  = false,
            AllowedCorsOrigins ={ "https://localhost:5001" },
            AllowedScopes = { 
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
               // "username" 
                               },
            RedirectUris = { "https://localhost:5001/authentication/login-callback" },
            PostLogoutRedirectUris = { "https://localhost:5001/" },
            Enabled = true
        
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
            Password = "password"
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "bob",
            Password = "password",
            
        }
              };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
           // new IdentityResource("username",new List<string>(){"username", })
        };
        }

    }
}
