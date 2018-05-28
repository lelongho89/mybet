using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FunBet.MultiTenancy.Dto;

namespace FunBet.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
