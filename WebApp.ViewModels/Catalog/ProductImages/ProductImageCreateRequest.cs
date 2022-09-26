using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.Catalog.ProductImages
{
    public class ProductImageCreateRequest
    {   

        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }

        public int SortOrder { get; set; }
        
        public IFormFile imageFile { get; set; }
        
    }
}
