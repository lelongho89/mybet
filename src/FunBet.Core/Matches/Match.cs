using Abp.Domain.Entities;
using FunBet.Stages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Matches
{
    [Table("AppMatches")]
    public class Match : Entity
    {
        public int StageId { get; set; }
        [ForeignKey("StageId")]
        public virtual Stage Stage { get; set; }
    }
}
