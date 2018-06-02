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
        public DateTime Date { get; set; }
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
        public bool HasBet { get; set; }
    }
}
