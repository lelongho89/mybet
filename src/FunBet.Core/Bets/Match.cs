using Abp.Domain.Entities;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets
{
    [Table("AppMatches")]
    public class Match : Entity
    {
        public DateTime StartTime { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Avenue { get; set; }
        public string Group { get; set; }
        public string FinalScore { get; set; }
        public bool Finished { get; set; }

        public bool IsOKToBet()
        {
            // Check if a valid bet
            // Cannot bet a past match
            // Cannot bet after 80'
            if (Clock.Now > StartTime.AddMinutes(80))
            {
                return false;
            }
            return true;
        }
    }
}
