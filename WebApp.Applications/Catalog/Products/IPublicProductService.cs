using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Applications.Catalog.Products.Dtos;
using WebApp.Applications.Catalog.Products.Dtos.Public;
using WebApp.Applications.Dtos;

namespace WebApp.Applications.Catalog.Products
{
    public interface IPublicProductService
    {
       Task<PageResult<ProductViewModel>> GetAllByCategory(GetProductPagingRequest request);
    }
}
