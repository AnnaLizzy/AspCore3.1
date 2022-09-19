using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebApp.Applications.Catalog.Products;
using WebApp.ViewModels.Catalog.Products;

namespace WebApp.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManagerProductService _managerProductService;
        public ProductController(IPublicProductService publicProductService,
            IManagerProductService managerProductService)
        {
            _publicProductService = publicProductService;
            _managerProductService = managerProductService;
        }
        //
        [HttpGet("{languageId}")]
        public async Task<IActionResult> Get(string languageId)
        {
            var products = await _publicProductService.GetAll(languageId);
            return Ok(products);
        }
        //
        [HttpGet("public-paging/{languageId}")]
        public async Task<IActionResult> Get([FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryById(request);
            return Ok(products);
        }
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id, string languageId)
        {
            var product = await _managerProductService.GetById(id,languageId);
            if(product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            var productId = await _managerProductService.Create(request);
            if(productId == 0)
                return BadRequest();

            var product = await _managerProductService.GetById(productId,request.LangugeId);

            return CreatedAtAction(nameof(GetById), new {id = productId} , product);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var effectedResult = await _managerProductService.Update(request);
            if (effectedResult == 0)
                return BadRequest();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var effectedResult = await _managerProductService.Delete(id);
            if (effectedResult == 0)
                return BadRequest();

            return Ok();
        }
        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery] int id, decimal newPrice)
        {
            var isSuccesful = await _managerProductService.UpdatePrice(id,newPrice);
            if (isSuccesful)
                return Ok();

            return BadRequest();
        }
    }
}
