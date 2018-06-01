using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Stages
{
    [Table("AppStages")]
    public class Stage : Entity
    {
        public string Name { get; set; }
    }
}
