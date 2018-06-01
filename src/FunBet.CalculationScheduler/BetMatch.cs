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
        public int? HomePredict { get; set; }
        public int? AwayPredict { get; set; }
        public int? HomeResult { get; set; }
        public int? AwayResult { get; set; }
    }
}
