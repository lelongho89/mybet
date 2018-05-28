using FunBet.CalculationRules;
using FunBet.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets
{
    public class ScoreManager : IScoreManager
    {
        private readonly List<IPointCalculationRule> _rules;
        private IScoreParser _scoreParser;

        public ScoreManager()
        {
            this._rules = new List<IPointCalculationRule>();
        }

        public ScoreManager(IScoreParser scoreParser)
        {
            this._rules = new List<IPointCalculationRule>();
            this._scoreParser = scoreParser;
        }

        public void AddRule(IPointCalculationRule rule)
        {
            this._rules.Add(rule);
        }

        public int CalculateScore(string predictScoreValue, string resultScoreValue)
        {
            var predictScore = _scoreParser.Parse(predictScoreValue);
            var resultScore = _scoreParser.Parse(resultScoreValue);

            var totalPoint = 0;

            if (predictScore is NullScore) return 0;

            foreach (var rule in _rules)
            {
                // If match a rule then we don't need to calculate next rules.
                if (totalPoint > 0) break;

                totalPoint += rule.Calculate(predictScore, resultScore);
            }

            return totalPoint;
        }

    }
}
