using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Matches.Dto
{
    public class GetAllOutput
    {
        public List<MatchDto>  Matches { get; set; }
        public List<GroupDto> Groups { get; set; }
    }
}
