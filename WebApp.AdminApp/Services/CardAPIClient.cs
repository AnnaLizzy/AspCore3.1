using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApp.Utilities.Constants;
using WebApp.ViewModels.Catalog.Card;
using WebApp.ViewModels.Common;

namespace WebApp.AdminApp.Services
{
    public class CardAPIClient : BaseApiClient,ICardAPIClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CardAPIClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration) : base(httpClientFactory, configuration, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> Create(CardCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstant.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var createTime = new CardCreateRequest() { CreatedTime = DateTime.Now };
            var requestContent = new MultipartFormDataContent
            {
                { new StringContent(request.AdminID.ToString()), "adminid" },
                { new StringContent(request.Color.ToString()), "color" },
                { new StringContent(request.CardNumber.ToString()), "cardnumber" },
                { new StringContent(request.SerialNumber.ToString()), "serialnumber" },
                { new StringContent(request.Status.ToString()), "status" },
                { new StringContent(request.Company.ToString()), "company" },
                { new StringContent(createTime.ToString()), "createdtime" },
                { new StringContent(request.EndTime.ToString()), "endtime" },
                { new StringContent(request.Type.ToString()), "type" },

            };

            var response = await client.PostAsync($"/api/card/", requestContent);//400

            return response.IsSuccessStatusCode;
        }

        public async Task<PageResult<CardViewModel>> GetPaging(GetManageCardPagingRequest request)
        {
            var data = await GetAsync<PageResult<CardViewModel>>(
                $"/api/card/paging?PageIndex={request.PageIndex}" + $"&PageSize={request.PageSize}" +
                 $"&Keyword={request.Keyword}");
            return data;//null items
        }
    }
}
