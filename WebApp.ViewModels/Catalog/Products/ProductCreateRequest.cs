using Microsoft.AspNetCore.Http;

namespace WebApp.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal OriginPrice { set; get; }
        public decimal Price { set; get; }
        public int Stock { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDecreption { set; get; }
        public string SeoAlias { set; get; }
        public string SeoTitle { set; get; }
        public string LangugeId { set; get; }
        public IFormFile ThumbnailImage { set; get; }
    }
}
