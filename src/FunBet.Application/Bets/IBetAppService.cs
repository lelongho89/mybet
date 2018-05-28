using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FunBet.Bets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets
{
    public interface IBetAppService : IApplicationService
    {
        void Bet(BetInput input);
        ListResultDto<MatchDto> GetAllMatches(GetAllMatchesInput input);
    }
}
