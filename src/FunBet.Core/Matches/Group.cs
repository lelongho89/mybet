using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Matches
{
    [Table("AppGroups")]
    public class Group : Entity
    {
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public int? Winner { get; set; }
        public int? RunnerUp { get; set; }
    }
}
