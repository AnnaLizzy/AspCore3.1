using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebApp.AdminApp.Services;
using WebApp.Data.Entities;
using WebApp.ViewModels.Catalog.Card;

namespace WebApp.AdminApp.Controllers
{
    public class CardController : BaseController
    {
        private readonly ICardAPIClient _cardAPIClient;
        private readonly IConfiguration _configuration;
        public CardController (ICardAPIClient cardAPIClient, IConfiguration configuration)
        {
            _cardAPIClient = cardAPIClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageCardPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _cardAPIClient.GetPaging(request);//items null
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CardCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            var result = await _cardAPIClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới thất bại");
            return View(request);
        }
    }
}
