using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication.WebApp.Areas.Identity.Data;
using WebApplication.WebApp.Views.Shared.Components;

namespace WebApplication.WebApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<WebApplicationWebAppUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<WebApplicationWebAppUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage("/Login");
            }
            //if (!_signInManager.IsSignedIn(User)) return RedirectToPage("/Index");

            //await _signInManager.SignOutAsync();
            //_logger.LogInformation("Người dùng đăng xuất");


            //return ViewComponent(MessagePage.COMPONENTNAME,
            //    new MessagePage.Message()
            //    {
            //        Title = "Đã đăng xuất",
            //        Htmlcontent = "Đăng xuất thành công",
            //        Urlredirect = returnUrl ?? Url.Page("/Index")
            //    }
            //);
        }
    }
}
