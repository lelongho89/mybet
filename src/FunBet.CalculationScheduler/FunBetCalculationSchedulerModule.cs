using Abp.Modules;
using FunBet.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.CalculationScheduler
{
    [DependsOn(typeof(FunBetCoreModule), typeof(FunBetDataModule))]
    public class FunBetCalculationSchedulerModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Database.SetInitializer<FunBetDbContext>(null);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
