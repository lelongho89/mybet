using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using FunBet.EntityFramework;

namespace FunBet.Migrator
{
    [DependsOn(typeof(FunBetDataModule))]
    public class FunBetMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<FunBetDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}