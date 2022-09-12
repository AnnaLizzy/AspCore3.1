using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Applications.Catalog.Products.Dtos;
using WebApp.Applications.Catalog.Products.Dtos.Manage;
using WebApp.Applications.Dtos;

namespace WebApp.Applications.Catalog.Products
{
    public interface IManagerProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int ProductId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productIdt);    
        Task<PageResult<ProductViewModel>>GetAllPaging(GetProductPagingRequest request);
    }
}
