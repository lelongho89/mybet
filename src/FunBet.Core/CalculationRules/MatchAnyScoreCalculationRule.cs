using FunBet.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.CalculationRules
{
    /// <summary>
    /// If prediction match a score of home or away then get the point
    /// </summary>

    public class MatchAnyScoreCalculationRule : IPointCalculationRule
    {
        /// <summary>
        /// Score will be added if match the rule.
        /// </summary>
        private int _point { get; set; }

        public MatchAnyScoreCalculationRule()
        {
            this._point = 1;
        }

        public MatchAnyScoreCalculationRule(int point)
        {
            this._point = point;
        }

        public int Calculate(Score predict, Score result)
        {
            var isMatch = predict.HomeScore == result.HomeScore || predict.AwayScore == result.AwayScore;

            return isMatch ? this._point : 0;
        }
    }
}
