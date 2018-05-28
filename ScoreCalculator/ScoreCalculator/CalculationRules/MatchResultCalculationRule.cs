using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.CalculationRules
{
    /// <summary>
    /// Match a win or lose
    /// </summary>

    public class MatchResultCalculationRule : IPointCalculationRule
    {
        /// <summary>
        /// Match Win/Lose/Draw.
        /// </summary>
        private int _point { get; set; }

        public MatchResultCalculationRule()
        {
            this._point = 3; // default point
        }

        public MatchResultCalculationRule(int point)
        {
            this._point = point;
        }

        public int Calculate(Score predict, Score result)
        {
            var isMatch = false;

            var predictDiff = predict.HomeScore - predict.AwayScore;
            var resultDiff = result.HomeScore - result.AwayScore;

            // Match Win/Lose/Draw
            isMatch = (predictDiff > 0 && resultDiff > 0) || (predictDiff == 0 && resultDiff == 0) || (predictDiff < 0 && resultDiff < 0);

            return isMatch ? this._point : 0;
        }
    }
}
