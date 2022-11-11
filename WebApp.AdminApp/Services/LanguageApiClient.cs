using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace WebApp.AdminApp.Services
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient 
    {
        public LanguageApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, configuration, httpContextAccessor)
        {           
        }
        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            return await GetAsync<ApiResult<List<LanguageVm>>>("/api/languages");
        }
    }
}
