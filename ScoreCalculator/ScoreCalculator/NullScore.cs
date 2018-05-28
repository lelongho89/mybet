using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator
{
    public class NullScore : Score
    {
        public NullScore()
        {
            HomeScore = -1;
            AwayScore = -1;
        }
    }
}
