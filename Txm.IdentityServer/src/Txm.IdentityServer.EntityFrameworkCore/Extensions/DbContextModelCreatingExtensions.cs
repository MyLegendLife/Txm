using Microsoft.EntityFrameworkCore;
using Txm.IdentityServer.Domain;

namespace Txm.IdentityServer.EntityFrameworkCore.Extensions
{
    public static class DbContextModelCreatingExtensions
    {
        public static void ConfigureConfigurationDb(this ModelBuilder b)
        {
            
        }

        public static void ConfigurePersistedGrantDb(this ModelBuilder b)
        {
           
        }

        public static void ConfigureIdentityDb(this ModelBuilder b)
        {
            b.Entity<TxmUser>(b =>
            {
                b.ToTable("Txm_User");
            });

            b.Entity<TxmUserClaim>(b =>
            {
                b.ToTable("Txm_UserClaim");
            });

            b.Entity<TxmUserRole>(b =>
            {
                b.ToTable("Txm_UserRole");
            });

            b.Entity<TxmUserLogin>(b =>
            {
                b.ToTable("Txm_UserLogin");
            });

            b.Entity<TxmUserToken>(b =>
            {
                b.ToTable("Txm_UserToken");
            });

            b.Entity<TxmRole>(b =>
            {
                b.ToTable("Txm_Role");
            });

            b.Entity<TxmRoleClaim>(b =>
            {
                b.ToTable("Txm_RoleClaim");
            });
        }
    }
}
