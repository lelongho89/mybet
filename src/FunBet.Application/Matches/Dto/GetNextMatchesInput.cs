using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Matches.Dto
{
    public class GetNextMatchesInput : IShouldNormalize
    {
        public int MaxResultCount { get; set; }

        public void Normalize()
        {
            this.MaxResultCount = 6;
        }
    }
}
