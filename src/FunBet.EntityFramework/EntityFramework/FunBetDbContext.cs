using System.Data.Common;
using Abp.Zero.EntityFramework;
using FunBet.Authorization.Roles;
using FunBet.Authorization.Users;
using FunBet.MultiTenancy;

namespace FunBet.EntityFramework
{
    public class FunBetDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public FunBetDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in FunBetDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of FunBetDbContext since ABP automatically handles it.
         */
        public FunBetDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public FunBetDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public FunBetDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
