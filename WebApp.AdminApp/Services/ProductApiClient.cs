
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
using System.IO;
using WebApp.Utilities.Constants;

namespace WebApp.AdminApp.Services
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration) : base(httpClientFactory,configuration, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
   

        public async Task<bool> Create(ProductCreateRequest request)
        {
            {
                var sessions = _httpContextAccessor
                .HttpContext
                .Session
                    .GetString(SystemConstant.AppSettings.Token);

                var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.DefaultLanguageId);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstant.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var requestContent = new MultipartFormDataContent();

                if (request.ThumbnailImage != null)
                {
                    byte[] data;
                    using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                    }
                    ByteArrayContent bytes = new ByteArrayContent(data);
                    requestContent.Add(bytes, "thumbnailImage", request.ThumbnailImage.FileName);
                }

                requestContent.Add(new StringContent(request.Price.ToString()), "price");
                requestContent.Add(new StringContent(request.OriginPrice.ToString()), "originalPrice");
                requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
                requestContent.Add(new StringContent(request.Name.ToString()), "name");
                requestContent.Add(new StringContent(request.Description.ToString()), "description");

                requestContent.Add(new StringContent(request.Details.ToString()), "details");
                requestContent.Add(new StringContent(request.SeoDecreption.ToString()), "seoDescription");
                requestContent.Add(new StringContent(request.SeoTitle.ToString()), "seoTitle");
                requestContent.Add(new StringContent(request.SeoAlias.ToString()), "seoAlias");
                requestContent.Add(new StringContent(languageId), "languageId");

                var response = await client.PostAsync($"/api/product/",requestContent);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<PageResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request)
        {
           var data = await GetAsync<PageResult<ProductViewModel>>(
               $"/api/product/paging?PageIndex={request.PageIndex}" + $"&PageSize={request.PageSize}" +
                $"&Keyword={request.Keyword}" +
                $"&languageid={request.LanguageId}");
           
            return data;
        }
    }
}
