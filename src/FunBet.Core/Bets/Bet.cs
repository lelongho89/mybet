using Abp.Domain.Entities.Auditing;
using FunBet.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets
{
    [Table("AppBets")]
    public class Bet : AuditedEntity
    {
        public virtual int MatchId { get; protected set; }

        [ForeignKey("MatchId")]
        public virtual Match Match { get; set; }

        public long PredictorId { get; set; }

        [ForeignKey("PredictorId")]
        public virtual User Predictor { get; set; }

        public string PredictScore { get; set; }

        public DateTime PredictTime { get; set; }

        public bool IsProcessed { get; set; }
    }
}
