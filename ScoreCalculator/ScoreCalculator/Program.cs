using ScoreCalculator.CalculationRules;
using ScoreCalculator.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var scoreParser = new ScoreParser();
            var scoreManager = new ScoreManager(scoreParser);

            scoreManager.AddRule(new MatchExactlyCalculationRule(5));
            scoreManager.AddRule(new MatchResultCalculationRule(3));
            scoreManager.AddRule(new MatchAnyScoreCalculationRule(1));

            var totalPoint = 0;
            totalPoint += scoreManager.CalculateScore("1-1", "0-0");
            totalPoint += scoreManager.CalculateScore("2-0", "0-0");

            Console.WriteLine($"You got {totalPoint} point(s)");

            Console.ReadKey();
        }
    }
}
