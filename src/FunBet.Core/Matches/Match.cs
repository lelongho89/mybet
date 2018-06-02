using Abp.Domain.Entities;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Matches
{
    [Table("AppMatches")]
    public class Match : Entity
    {
        private const int MaxTypeLength = 20;

        public int? TenantId { get; set; }

        public int Name { get; set; }
        /// <summary>
        /// A/B/C/D/E/F/G/H/R16/R8/R4/R2
        /// </summary>
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        /// <summary>
        /// Group/Qualified/Winner
        /// </summary>
        [MaxLength(MaxTypeLength)]
        public string Type { get; set; }
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
        public int? HomeResult { get; set; }
        public int? AwayResult { get; set; }
        public int? HomePenalty { get; set; }
        public int? AwayPenalty { get; set; }
        public int? Winner { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(250)]
        public string Stadium { get; set; }
        public bool Finished { get; set; }
        public int MatchDay { get; set; }

        public Match()
        {
        }

        public Match(int name, string type, int homeTeam, int awayTeam, DateTime date, bool finished, int matchDay)
        {
            Name = name;
            Type = type;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Date = date;
            Finished = finished;
            MatchDay = matchDay;
        }

        public Match(int name, int groupId, string type, int homeTeam, int awayTeam, int? homeResult, int? awayResult, int? homePenalty, int? awayPenalty, int? winner, DateTime date, string stadium, bool finished, int matchDay)
        {
            Name = name;
            GroupId = groupId;
            Type = type;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeResult = homeResult;
            AwayResult = awayResult;
            HomePenalty = homePenalty;
            AwayPenalty = awayPenalty;
            Winner = winner;
            Date = date;
            Stadium = stadium;
            Finished = finished;
            MatchDay = matchDay;
        }

        public bool IsOKToBet()
        {
            // Check if a valid bet
            // Cannot bet a past match
            // Cannot bet after 80'
            if (Clock.Now > Date.AddMinutes(80))
            {
                return false;
            }
            return true;
        }
    }
}
