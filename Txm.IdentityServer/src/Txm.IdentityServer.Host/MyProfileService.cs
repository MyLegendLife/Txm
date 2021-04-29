using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Txm.IdentityServer.Domain;
using Txm.IdentityServer.EntityFrameworkCore;

namespace Txm.IdentityServer.Host
{
    internal class MyProfileService : IProfileService
    {
        private readonly TxmIdentityDbContext _context;
        private readonly IUserClaimsPrincipalFactory<TxmUser> _userClaimsPrincipalFactory;

        public MyProfileService(TxmIdentityDbContext context,
            UserClaimsPrincipalFactory<TxmUser> userClaimsPrincipalFactory)
        {
            _context = context;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            
        }
    }
}
