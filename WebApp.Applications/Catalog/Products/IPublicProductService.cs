using System.Threading.Tasks;
using WebApp.ViewModels.Catalog.Products;
using WebApp.ViewModels.Common;

namespace WebApp.Applications.Catalog.Products
{
    public interface IPublicProductService
    {
       Task<PageResult<ProductViewModel>> GetAllCategoryById(GetManageProductPagingRequest request);
    }
}
