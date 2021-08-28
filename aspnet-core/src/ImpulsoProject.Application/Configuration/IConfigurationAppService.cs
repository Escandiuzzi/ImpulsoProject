using System.Threading.Tasks;
using ImpulsoProject.Configuration.Dto;

namespace ImpulsoProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
