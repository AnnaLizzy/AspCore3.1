using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.ViewModels.Common;

namespace WebApp.AdminApp.Controllers.Compoments
{
    public class PageViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase resultBase)
        {
            return Task.FromResult((IViewComponentResult)View("Default",resultBase));
        }
    }
}
