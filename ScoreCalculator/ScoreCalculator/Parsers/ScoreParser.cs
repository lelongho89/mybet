using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Parsers
{
    public class ScoreParser : IScoreParser
    {
        /// <summary>
        /// Allows delimiter: / or :
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public Score Parse(string score)
        {
            var nullScore = new NullScore();

            if (string.IsNullOrEmpty(score)) return nullScore;
            score = score.Replace(" ", "");

            // All possible delimiters
            Stack<string> delimiters = new Stack<string>();
            delimiters.Push("/");
            delimiters.Push(":");
            delimiters.Push("-");

            var delimiter = delimiters.Pop();
            while(score.IndexOf(delimiter) < 0)
            {
                if (delimiters.Count == 0)
                {
                    return nullScore;
                }

                delimiter = delimiters.Pop();
            }

            var scores = score.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if(scores.Length < 2)
            {
                // invalid score
                return nullScore;
            }

            var homeScore = -1;
            var awayScore = -1;

            int.TryParse(scores[0].Trim(), out homeScore);
            int.TryParse(scores[1].Trim(), out awayScore);

            return new Score(homeScore, awayScore);
        }
    }
}
