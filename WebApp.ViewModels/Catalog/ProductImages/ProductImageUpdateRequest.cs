using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.Catalog.ProductImages
{
    public class ProductImageUpdateRequest
    {
        public int Id { set; get; }

        public string Caption { set; get; }

        public bool IsDefault { set; get; }


        public int SortOrder { set; get; }

        public IFormFile ImageFile { set; get; }
    }
}
