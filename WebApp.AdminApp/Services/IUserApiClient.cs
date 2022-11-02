using System;
using System.Threading.Tasks;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Users;

namespace WebApp.AdminApp.Models.Services
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PageResult<UserVM>>> GetUserPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);
        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<ApiResult<UserVM>> GetById(Guid id);
        Task<ApiResult<bool>> DeleteUser(Guid id);
    }
}
