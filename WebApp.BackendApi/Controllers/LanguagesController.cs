using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Applications.System.Languages;

namespace WebApp.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguagesService _languagesService;

        public LanguagesController(ILanguagesService languagesService)
        {
            _languagesService = languagesService;
        }
       
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _languagesService.GetAll();
            return Ok(products);
        }
    }
}
