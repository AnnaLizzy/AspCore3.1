using System.Threading.Tasks;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Users;

namespace WebApp.AdminApp.Models.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PageResult<UserVM>> UserPagings(GetUserPagingRequest request);
    }
}
