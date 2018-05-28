using FunBet.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.CalculationRules
{
    public interface IPointCalculationRule
    {
        int Calculate(Score predict, Score result);
    }
}
