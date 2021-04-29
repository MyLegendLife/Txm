using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Txm.IdentityServer.Host.Configs
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>

            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2")
            };

        public static IEnumerable<ApiResource> GetApiResources()
        {
            //var customProfile = new IdentityResource(
            //    name: "custom.profile",
            //    displayName: "Custom profile",
            //    userClaims: new[] { "role" });
            
            return new[]
            {
                new ApiResource("Txm.Identity", "身份服务",new List<string>(){JwtClaimTypes.Role})
                {
                    Scopes = { "scope1", "scope2" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "Txm.BackendAdmin",
                    ClientName = "后台管理",
                    ClientSecrets = new [] { new Secret("txm".Sha256()) },
                    AllowedGrantTypes = {
                        GrantType.ClientCredentials,
                        GrantType.ResourceOwnerPassword,
                        GrantType.Implicit,
                    },
                    // 登录成功回调处理地址，处理回调返回的数据
                    //RedirectUris = { "https://localhost:7001/signin-oidc" },
                    RedirectUris = { "https://localhost:7001/home/secure" },
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:7001/signout-callback-oidc" },
                    AllowedScopes = new [] 
                    { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "scope1"
                    }
                }
            };
        }
    }
}
