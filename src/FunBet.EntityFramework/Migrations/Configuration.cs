using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using FunBet.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace FunBet.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FunBet.EntityFramework.FunBetDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FunBet";
        }

        protected override void Seed(FunBet.EntityFramework.FunBetDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();

                // Seed data
                new TeamsCreator(context).Create();
                new GroupsCreator(context).Create();
                new MatchesCreator(context).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
