using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Standings.Dto
{
    [AutoMapFrom(typeof(Standing))]
    public class StandingDto : EntityDto
    {
        public long PredictorId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
