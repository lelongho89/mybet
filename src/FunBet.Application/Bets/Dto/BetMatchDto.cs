using Abp.AutoMapper;
using Abp.Timing;
using FunBet.Matches;
using FunBet.Matches.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets.Dto
{
    [AutoMapFrom(typeof(Match))]
    public class BetMatchDto : MatchDto
    {
        public int? BetId { get; set; }
        public long PredictorId { get; set; }
        public int? HomePredict { get; set; }
        public int? AwayPredict { get; set; }
        public bool CanBet
        {
            get
            {
                return Clock.Now > Date.AddMinutes(75);
            }
            
        }
    }
}
