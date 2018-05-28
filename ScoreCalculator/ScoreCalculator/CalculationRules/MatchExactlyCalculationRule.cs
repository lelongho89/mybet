using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.CalculationRules
{
    /// <summary>
    /// Match exactly score
    /// </summary>

    public class MatchExactlyCalculationRule : IPointCalculationRule
    {
        /// <summary>
        /// Score will be added if match the rule.
        /// </summary>
        private int _point { get; set; }

        public MatchExactlyCalculationRule()
        {
            this._point = 5; // default point
        }

        public MatchExactlyCalculationRule(int point)
        {
            this._point = point;
        }

        public int Calculate(Score predict, Score result)
        {
             // Match exactly scores.
             var isMatch = predict.HomeScore == result.HomeScore && predict.AwayScore == result.AwayScore;

            return isMatch ? this._point : 0;
        }
    }
}
