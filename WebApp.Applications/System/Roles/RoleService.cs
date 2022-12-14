using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.Data.Entities;
using WebApp.ViewModels.System.Roles;

namespace WebApp.Applications.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AdminRole> _roleManager;

        public RoleService(RoleManager<AdminRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<List<RoleVm>> GetAll()
         {
            var roles = await _roleManager.Roles.Select(x => new RoleVm()
            {
                Description = x.Decreption,
                Id = x.Id,
                Name = x.Name,
               
            }).ToListAsync();
             return roles;
         }
        
    }
}
