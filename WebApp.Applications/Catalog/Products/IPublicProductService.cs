using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Applications.Catalog.Products.Dtos;
using WebApp.Applications.Dtos;

namespace WebApp.Applications.Catalog.Products
{
    public interface IPublicProductService
    {
        public PageViewModel<ProductViewModel> GetAllByCategory(int categoryId,
            int pageIndex, int PageSize);
    }
}
