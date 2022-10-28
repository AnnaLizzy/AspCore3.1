using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Applications.Catalog.Products;
using WebApp.ViewModels.Catalog.ProductImages;
using WebApp.ViewModels.Catalog.Products;


namespace WebApp.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //http://localhost:port/product?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _productService.GetAllByCategoryId(languageId, request);
            return Ok(products);
        }
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Khong tim thay ma san pham");
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productService.GetById(productId, request.LangugeId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }
        //PUT localhost/api/user/
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var effectedResult = await _productService.Update(request);
            if (effectedResult == 0)
                return BadRequest();

            return Ok();
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var effectedResult = await _productService.Delete(productId);
            if (effectedResult == 0)
                return BadRequest();

            return Ok();
        }
        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery] int productId, decimal newPrice)
        {
            var isSuccesful = await _productService.UpdatePrice(productId, newPrice);
            if (isSuccesful)
                return Ok();

            return BadRequest();
        }
        //Images
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _productService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetById), new { id = imageId }, imageId);
        }
        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();


            return Ok();
        }
        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{productId}/{images}/{imageId}")]
        public async Task<IActionResult> GetById(int productId, int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }

    }
}
