using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace WebApp.Applications.System.User
{
     public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest register);
        Task<PageResult<UserVM>> GetUserPaging(GetUserPagingRequest request);
    }
}
