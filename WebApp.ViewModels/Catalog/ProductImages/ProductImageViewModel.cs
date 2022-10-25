using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.Catalog.ProductImages
{
    public class ProductImageViewModel
    {
        public int Id { set; get; }

        public int ProductId { set; get; }

        public string ImagePath { set; get; }

        public string Caption { set; get; }

        public bool IsDefault { set; get; }

        public DateTime DateCreated { set; get; }

        public int SortOrder { set; get; }

        public long FileSize { set; get; }

    }
}
