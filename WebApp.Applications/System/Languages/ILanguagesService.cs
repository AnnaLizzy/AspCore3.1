using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Languages;


namespace WebApp.Applications.System.Languages
{
    public interface ILanguagesService
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();       
    }
}
