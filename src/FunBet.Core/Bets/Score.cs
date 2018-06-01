using Abp.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets
{
    public class Score : ValueObject<Score>
    {
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public Score()
        {
        }

        public Score(int home, int away)
        {
            this.HomeScore = home;
            this.AwayScore = away;
        }

        public bool IsInvalidScore()
        {
            return (HomeScore == -1 || AwayScore == -1);
        }
    }
}
