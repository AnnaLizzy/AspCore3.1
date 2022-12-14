using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly UserManager<Admin> _userManager;
        private readonly SignInManager<Admin> _signInManager;
        private readonly RoleManager<AdminRole> _roleManager;

        private readonly IConfiguration _config;
        public UserService(UserManager<Admin> userManager, SignInManager<Admin> signInManager,
            RoleManager<AdminRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            
            var user = await _userManager.FindByNameAsync(request.UserName);           
            if (user == null)
                return new ApiErrorResult<string>("Tài khoản không tồn tại");
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Sai mật khẩu");
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

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));


        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.EmployNO);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Notes) != null)
            {
                return new ApiErrorResult<bool>("Email dã tồn tại");
            }
            user = new Admin()
            {
                
                Dob = request.Dob,
                Email = request.Notes,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.EmployNO,
                PhoneNumber = request.PhoneNumber,
                EmployNO= request.EmployNO,

            };
            var resutl = await _userManager.CreateAsync(user, request.Password);
            if (resutl.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng kí không thành công");
        }


        public async Task<ApiResult<PageResult<UserVM>>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword)
                || x.PhoneNumber.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)//
                .Take(request.PageSize)
                .Select(x => new UserVM
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Id = x.Id,
                    PhoneNumber =x.PhoneNumber,
                    UserName = x.UserName
                }).ToListAsync();

            var pagedResult = new PageResult<UserVM>()
            {
                TotalRecords = totalRow,
                Items = data,
            };
            return new ApiSuccessResult<PageResult<UserVM>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Dob = request.Dob;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<ApiResult<UserVM>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserVM>("User không tồn tại");
            }
            var role = await _userManager.GetRolesAsync(user);
            var userVm = new UserVM()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Dob = user.Dob,
                Roles = role
            };
            return new ApiSuccessResult<UserVM>(userVm);
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return new ApiSuccessResult<bool>();
           
            return new ApiErrorResult<bool>("Xóa không thành công");
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());//fix find by id
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }
            var removeRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();           
            foreach (var roleName in removeRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            var addRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addRoles)
            {
                if (await _userManager.IsInRoleAsync(user,roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user,roleName);
                }
               
            }
            return new ApiSuccessResult<bool>();
           
        }
    }
}
