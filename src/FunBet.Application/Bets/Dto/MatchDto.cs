using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using FunBet.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets.Dto
{
    [AutoMapFrom(typeof(Match))]
    public class MatchDto : EntityDto
    {
        public DateTime StartTime { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Avenue { get; set; }
        public string Group { get; set; }
        public string FinalScore { get; set; }
        public bool HasBet { get; set; }
    }
}
