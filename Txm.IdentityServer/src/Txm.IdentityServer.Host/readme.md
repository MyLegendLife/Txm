更新IdentityServer数据库，一共两个上下文，分别执行
add-migration InitialConfigurationDb -c TxmConfigurationDbContext -o Migrations/IdentityServer/ConfigurationDb
update-database -c TxmConfigurationDbContext

add-migration InitialPersistedGrantDb -c TxmPersistedGrantDbContext -o Migrations/IdentityServer/PersistedGrantDb
update-database -c TxmPersistedGrantDbContext

更新AspNetCoreIdentity数据库
add-migration InitialIdentity -c TxmIdentityDbContext -o Migrations/IdentityDb
update-database -c TxmIdentityDbContext