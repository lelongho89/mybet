using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using FunBet.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Matches.Dto
{
    [AutoMapFrom(typeof(Match))]
    public class MatchDto : EntityDto
    {
        public int Name { get; set; }
        public DateTime Date { get; set; }
        public string GroupName { get; set; }
        public string Type { get; set; }
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamIso2 { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamIso2 { get; set; }
        public int HomeResult { get; set; }
        public int AwayResult { get; set; }
        public int HomePenalty { get; set; }
        public int AwayPenalty { get; set; }
        public bool Finished { get; set; }
        public bool HasBet { get; set; }

        public bool IsHomeTeamWin()
        {
            return HomeResult > AwayResult || HomePenalty > AwayPenalty;
        }

        public bool IsHomeTeamDraw()
        {
            return HomeResult == AwayResult;
        }
    }
}
