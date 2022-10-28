using System;
using System.Threading.Tasks;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Users;


namespace WebApp.Applications.System.User
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);
        Task<ApiResult<PageResult<UserVM>>> GetUserPaging(GetUserPagingRequest request);
        Task<ApiResult<UserVM>> GetById(Guid id);
    }
}
