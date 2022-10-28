using Microsoft.AspNetCore.Http;
using System;

namespace WebApp.ViewModels.Catalog.ProductImages
{
    public class ProductImageCreateRequest
    {

        public string Caption { set; get; }

        public bool IsDefault { set; get; }

        public DateTime DateCreated { set; get; }
        public int SortOrder { set; get; }

        public IFormFile ImageFile { set; get; }
    }
}
