using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FunBet.Configuration.Dto;

namespace FunBet.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FunBetAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
