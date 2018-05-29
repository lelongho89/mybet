using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.CalculationScheduler
{
    [DependsOn(typeof(FunBetDataModule))]
    public class FunBetCalculationSchedulerModule : AbpModule
    {
    }
}
