using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator
{
    public interface IScoreParser
    {
        /// <summary>
        /// Parse a score string, e.g 1-0/1-1/1-2
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        Score Parse(string score);
    }
}
