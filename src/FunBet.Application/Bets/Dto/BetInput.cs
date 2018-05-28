using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets.Dto
{
    [AutoMapTo(typeof(Bet))]
    public class BetInput
    {
        public int? Id { get; set; }
        public int MatchId { get; set; }
        public string PredictScore { get; set; }
    }
}
