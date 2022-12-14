using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using WebApp.ViewModels.Catalog.Products;
using WebApp.ViewModels.Common;
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

                var requestContent = new MultipartFormDataContent
                    {
                        {new StringContent(request.Price.ToString()), "price" },
                        {new StringContent(request.OriginPrice.ToString()), "originalprice" },
                        {new StringContent(request.Stock.ToString()), "stock" },
                        {new StringContent(request.Name.ToString()), "name" },
                        {new StringContent(request.Description.ToString()), "description"},
                        {new StringContent(request.Details.ToString()), "details"},
                        {new StringContent(request.SeoDecription.ToString()), "seodecription"},
                        {new StringContent(request.SeoTitle.ToString()), "seotitle" },
                        {new StringContent(request.SeoAlias.ToString()), "seoalias" },
                        {new StringContent(languageId.ToString()), "languageid" },                   
                     };
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

                //requestContent.Add(new StringContent(request.Price.ToString()), "price");
                //requestContent.Add(new StringContent(request.OriginPrice.ToString()), "originalprice");
                //requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
                //requestContent.Add(new StringContent(request.Name.ToString()), "name");
                //requestContent.Add(new StringContent(request.Description.ToString()), "description");
                //requestContent.Add(new StringContent(request.Details.ToString()), "details");
                //requestContent.Add(new StringContent(request.SeoDecription.ToString()), "seodecription");
                //requestContent.Add(new StringContent(request.SeoTitle.ToString()), "seotitle");
                //requestContent.Add(new StringContent(request.SeoAlias.ToString()), "seoalias");
                //requestContent.Add(new StringContent(languageId.ToString()), "languageId");

                var response = await client.PostAsync($"/api/product/", requestContent);//500

                    return response.IsSuccessStatusCode;
               
               
            }
        }
        public async Task<PageResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request)
        {
           var data = await GetAsync<PageResult<ProductViewModel>>(
               $"/api/product/paging?pageIndex={request.PageIndex}" + $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}" +
                $"&languageid={request.LanguageId}");           
            return data;
        }
    }
}
