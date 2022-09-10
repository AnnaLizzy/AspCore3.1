using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Applications.Catalog.Products.Dtos
{
    public class ProductEditRequest
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string SeoDecreption { get; set; }
        public string SeoAlias { get; set; }
        public string SeoTitle { get; set; }
        public string LangugeId { get; set; }
    }
}
