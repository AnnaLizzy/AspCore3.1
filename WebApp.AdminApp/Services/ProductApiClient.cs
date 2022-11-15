using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using WebApp.ViewModels.Catalog.Products;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace WebApp.AdminApp.Services
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        public ProductApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor) : base(httpClientFactory,configuration, httpContextAccessor)
        {     
        }
        public async Task<ApiResult<PageResult<ProductViewModel>>> GetPagings(GetManageProductPagingRequest request)
        {
           var data = await base.GetAsync<ApiResult<PageResult<ProductViewModel>>>($"/api/user/paging?PageIndex=" +
                $"{request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}");
           
            return data;
        }
    }
}
