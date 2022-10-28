using Microsoft.AspNetCore.Http;

namespace WebApp.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Detail { set; get; }
        public string SeoDecreption { set; get; }
        public string SeoAlias { set; get; }
        public string SeoTitle { set; get; }
        public string LangugeId { set; get; }
        public IFormFile ThumbnailImage { set; get; }
    }
}
