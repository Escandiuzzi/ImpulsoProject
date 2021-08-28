using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ImpulsoProject.Configuration.Dto;

namespace ImpulsoProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ImpulsoProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
