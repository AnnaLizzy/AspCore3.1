using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.Entities;
using WebApp.ViewModels.Catalog.Products;
using WebApp.ViewModels.Common;

namespace WebApp.Applications.Catalog.Products
{
    public interface IManagerProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);    
        Task<PageResult<ProductViewModel>>GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImages(int productId, List<IFormFile> files);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdateImages(int imageId, string caption, bool IsDeafault);
        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
