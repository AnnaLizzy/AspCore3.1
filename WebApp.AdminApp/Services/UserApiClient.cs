using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Users;

namespace WebApp.AdminApp.Models.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //IHttpClientFactory goi WebApI
        public UserApiClient (IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public  async Task<string> Authenticate(LoginRequest request)
        {
            var Json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(Json,Encoding.UTF8,"application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/user/authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }

        public Task<PageResult<UserVM>> UserPagings(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
