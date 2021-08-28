using System.Threading.Tasks;
using Abp.Application.Services;
using ImpulsoProject.Sessions.Dto;

namespace ImpulsoProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
