using Abp.Dependency;
using FunBet.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Parsers
{
    public interface IScoreParser : ITransientDependency
    {
        /// <summary>
        /// Parse a score string, e.g 1-0/1-1/1-2
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        Score Parse(string score);
    }
}
