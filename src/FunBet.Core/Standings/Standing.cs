using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Standings
{
    [Table("AppStandings")]
    public class Standing : Entity
    {
        public string PredictorUserName { get; set; }
        public string PredictorName { get; set; }
        public int Points { get; set; }
    }
}
