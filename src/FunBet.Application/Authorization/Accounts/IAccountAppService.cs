using System.Threading.Tasks;
using Abp.Application.Services;
using FunBet.Authorization.Accounts.Dto;

namespace FunBet.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
