using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Txm.IdentityServer.Domain;

namespace Txm.IdentityServer.Host
{
    public class UserClaimsPrincipal : IUserClaimsPrincipalFactory<TxmUser>
    {
        private readonly UserManager<TxmUser> _userManager;

        public UserClaimsPrincipal(UserManager<TxmUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ClaimsPrincipal> CreateAsync(TxmUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);

            var claimsIdentity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return await Task.FromResult(claimsPrincipal);

        }
    }
}