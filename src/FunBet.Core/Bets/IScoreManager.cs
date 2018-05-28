using Abp.Dependency;
using FunBet.CalculationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets
{
    public interface IScoreManager : ITransientDependency
    {
        void AddRule(IPointCalculationRule rule);
        int CalculateScore(string predictScoreValue, string resultScoreValue);
    }
}
