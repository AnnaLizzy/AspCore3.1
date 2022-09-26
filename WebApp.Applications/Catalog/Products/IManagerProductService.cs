using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.Catalog.ProductImages;
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
        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImage( int imageId);
        Task<int> UpdateImage( int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById (int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);
    }
}
