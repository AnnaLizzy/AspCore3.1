using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Dynamic.Core;
using System.Security.Claims;//
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.Entities;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Users;

namespace WebApp.Applications.System.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<string> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
               return null;
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe,true);
            if(!result.Succeeded)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
               new Claim(ClaimTypes.Email,user.Email),
               new Claim(ClaimTypes.GivenName,user.FirstName),
               new Claim(ClaimTypes.Role, string.Join(";", roles)),
               new Claim(ClaimTypes.Name,request.UserName)
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                       issuer: _config["Tokens:Issuer"],
                       audience: _config["Tokens:Issuer"],
                       claims,
                       expires: DateTime.Now.AddHours(3),
                       signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);    
        }
       
        public async Task<bool> Register(RegisterRequest register)
        {
            var user = new AppUser()
            {
                Dob = register.Dob,
                Email = register.Email,
                FirstName = register.FirtName,
                LastName = register.LastName,
                UserName = register.UserName,
                PhoneNumber = register.PhoneNumber,
                
            };
            var resutl = await _userManager.CreateAsync(user, register.Password );
            if(resutl.Succeeded)
            {
                return true;
            }
            return false;
        }


        public async Task <PageResult<UserVM>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(z => z.UserName.Contains(request.Keyword)
                || z.PhoneNumber.Contains(request.Keyword));
            }
           
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(z => new UserVM
                {
                    Email = z.Email,
                    FirstName = z.FirstName,
                    LastName = z.LastName,
                    Id = z.Id,
                    PhoneNumber = z.PhoneNumber,
                    UserName = z.UserName
                }).ToListAsync();
            
            var pagedResult = new PageResult<UserVM>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pagedResult;
        }
    }
}
