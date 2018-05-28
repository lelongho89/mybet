using System.Threading.Tasks;
using Abp.Application.Services;
using FunBet.Configuration.Dto;

namespace FunBet.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}