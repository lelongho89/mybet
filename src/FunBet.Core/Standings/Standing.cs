using Abp.Domain.Entities;
using FunBet.Authorization.Users;
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
        public long PredictorId { get; set; }

        [ForeignKey("PredictorId")]
        public virtual User Predictor { get; set; }
        public int Points { get; set; }
    }
}
