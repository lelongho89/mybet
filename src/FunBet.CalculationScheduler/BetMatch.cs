using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.CalculationScheduler
{
    public class BetMatch
    {
        public int BetId { get; set; }
        public int MatchId { get; set; }
        public long PredictorId { get; set; }
        public string PredictScore { get; set; }
        public string FinalScore { get; set; }
    }
}
