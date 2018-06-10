using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FunBet.Standings.Dto;

namespace FunBet.Standings
{
    public interface IStandingAppService : IApplicationService
    {
        ListResultDto<StandingDto> GetAll(GetAllInput input);
        GetPositionOutput GetPosition(GetPositionInput input);
    }
}