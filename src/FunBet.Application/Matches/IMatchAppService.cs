using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FunBet.Bets.Dto;
using FunBet.Matches.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Matches
{
    public interface IMatchAppService : IApplicationService
    {
        GetAllOutput GetAll(GetAllInput input);
    }
}
