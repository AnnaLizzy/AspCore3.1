using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.AdminApp.Models;
using WebApp.AdminApp.Services;
using WebApp.Utilities.Constants;

namespace WebApp.AdminApp.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ILanguageApiClient _languageApiClient;
        public NavigationViewComponent (ILanguageApiClient languageApiClient)
        {
            _languageApiClient = languageApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var language = await _languageApiClient.GetAll();//null
            var navigation = new NavigationViewModel()
            {
                CurrentLanguageId = HttpContext
                .Session
                .GetString(SystemConstant.AppSettings.DefaultLanguageId),
                Languages = language.ResultObj
            };
            return View("Default", navigation);
        }
    }
}
