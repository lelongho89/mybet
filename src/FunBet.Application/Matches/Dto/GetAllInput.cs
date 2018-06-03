using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Matches.Dto
{
    public class GetAllInput : ISortedResultRequest, IShouldNormalize
    {
        public string Sorting { get; set; }
        public int DisplayType { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Date ASC";
            }
        }
    }
}
