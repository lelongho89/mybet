using System.Threading.Tasks;
using Abp.Application.Services;
using FunBet.Sessions.Dto;

namespace FunBet.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
