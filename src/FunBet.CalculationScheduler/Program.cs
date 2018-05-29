using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Collections.Extensions;
using Abp.Dependency;
using Castle.Facilities.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.CalculationScheduler
{
    class Program
    {
        private static long _exactPredictorId = -1;
        public static void Main(string[] args)
        {
            ParseArgs(args);

            using (var bootstrapper = AbpBootstrapper.Create<FunBetCalculationSchedulerModule>())
            {
                bootstrapper.IocManager.IocContainer
                    .AddFacility<LoggingFacility>(f => f.UseAbpLog4Net()
                        .WithConfig("log4net.config")
                    );

                bootstrapper.Initialize();

                using (var calculationExecuter = bootstrapper.IocManager.ResolveAsDisposable<StandingsCalculationExcuter>())
                {
                    calculationExecuter.Object.Run(_exactPredictorId);
                }

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }

        private static void ParseArgs(string[] args)
        {
            if (args.IsNullOrEmpty())
            {
                return;
            }

            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                if(arg.StartsWith("-m"))
                {
                    var options = arg.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (options.Length > 1)
                        _exactPredictorId = long.Parse(options[1]);
                    break;
                }
            }
        }
    }
}
