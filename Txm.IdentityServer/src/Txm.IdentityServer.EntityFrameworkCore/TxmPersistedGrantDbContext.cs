using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Txm.IdentityServer.EntityFrameworkCore.Extensions;

namespace Txm.IdentityServer.EntityFrameworkCore
{
    public class TxmPersistedGrantDbContext : PersistedGrantDbContext<TxmPersistedGrantDbContext>
    {
        
        public TxmPersistedGrantDbContext(DbContextOptions<TxmPersistedGrantDbContext> options, OperationalStoreOptions storeOptions) 
            : base(options, storeOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigurePersistedGrantDb();
        }
    }
}
