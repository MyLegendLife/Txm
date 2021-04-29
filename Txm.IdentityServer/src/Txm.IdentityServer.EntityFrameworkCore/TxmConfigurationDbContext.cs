using System;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Txm.IdentityServer.Domain;
using Txm.IdentityServer.EntityFrameworkCore.Extensions;

namespace Txm.IdentityServer.EntityFrameworkCore
{
    public class TxmConfigurationDbContext : ConfigurationDbContext<TxmConfigurationDbContext>
    {
        
        public TxmConfigurationDbContext(DbContextOptions<TxmConfigurationDbContext> options, ConfigurationStoreOptions storeOptions) 
            : base(options, storeOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureConfigurationDb();
        }
    }
}
