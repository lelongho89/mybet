using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Matches.Dto
{
    [AutoMapFrom(typeof(Group))]
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MatchDto> Matches { get; set; }
    }
}
