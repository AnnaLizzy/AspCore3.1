﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal OriginPrice { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDecreption { get; set; }
        public string SeoAlias { get; set; }
        public string SeoTitle { get; set; }
        public string LangugeId { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
