using System.Collections.Generic;
using WebApp.ViewModels.System.Languages;

namespace WebApp.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageVm> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
    }
}
