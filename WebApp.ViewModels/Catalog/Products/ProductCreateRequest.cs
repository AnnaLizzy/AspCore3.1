using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [DisplayName("Giá gốc")]
        [Required(ErrorMessage = "Nhập giá gốc")]
        public decimal OriginPrice { set; get; }
        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Nhập giá bán")]
        public decimal Price { set; get; }
        [Display(Name = "Tồn kho")]
        public int Stock { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { set; get; }
        [Display(Name = "Miêu tả")]
        public string Description { set; get; }
        [Display(Name = "Chi tiết")]
        public string Details { set; get; }
        public string SeoDecreption { set; get; }
        public string SeoAlias { set; get; }
        public string SeoTitle { set; get; }
        public string LangugeId { set; get; }
        [Display(Name = "Hình ảnh")]
        public IFormFile ThumbnailImage { set; get; }
    }
}
