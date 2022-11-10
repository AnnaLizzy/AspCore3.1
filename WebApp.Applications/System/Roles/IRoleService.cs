using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.ViewModels.System.Roles;

namespace WebApp.Applications.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}
