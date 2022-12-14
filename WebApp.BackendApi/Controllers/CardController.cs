using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Applications.Catalog.Cards;
using WebApp.ViewModels.Catalog.Card;
using WebApp.ViewModels.Catalog.Products;

namespace WebApp.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        public readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CardCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cardId = await _cardService.Create(request);
            if (cardId == 0)
            {
                return BadRequest();
            }
            var cardid = await _cardService.GetById(cardId);
            return CreatedAtAction(nameof(GetById), cardid);
        }
        [HttpGet]
        public async Task<IActionResult> GetById (int CartId)
        {
            var cardId = await _cardService.GetById(CartId);
            if (cardId == null)
                return BadRequest("Không tìm thấy mã thẻ");
            return Ok(cardId);
        }
        [HttpDelete]
        public async Task<IActionResult> XOA (int CardID)
        {
            var xoa = await _cardService.Delete(CardID);
            if (xoa == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> CapNhat([FromForm]CardUpdateRequest request)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var cn = await _cardService.Update(request);
            if (cn == 0)
                return BadRequest();
            return Ok();

        }
        [HttpGet("{paging}")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageCardPagingRequest request)
        {
            var products = await _cardService.GetAllPaging(request);
            return Ok(products);
        }
    }
}
