using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Txm.IdentityServer.Domain;
using Txm.IdentityServer.EntityFrameworkCore.Extensions;

namespace Txm.IdentityServer.EntityFrameworkCore
{
    public class TxmIdentityDbContext : IdentityDbContext<TxmUser,TxmRole,Guid,TxmUserClaim,TxmUserRole,TxmUserLogin,TxmRoleClaim,TxmUserToken>
    {
        public TxmIdentityDbContext(DbContextOptions<TxmIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureIdentityDb();
        }
    }
}
