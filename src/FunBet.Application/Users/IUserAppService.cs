using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FunBet.Roles.Dto;
using FunBet.Users.Dto;

namespace FunBet.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}