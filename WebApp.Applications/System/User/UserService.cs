using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;//
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.Entities;
using WebApp.Utilities.Exceptions;
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
               new Claim(ClaimTypes.Role, string.Join(";", roles))
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Isssue"],
                       _config["Tokens: Issue"],
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
    }
}
