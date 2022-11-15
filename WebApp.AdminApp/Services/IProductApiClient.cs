using System.Threading.Tasks;
using WebApp.ViewModels.Catalog.Products;
using WebApp.ViewModels.Common;

namespace WebApp.AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<ApiResult<PageResult<ProductViewModel>>> GetPagings(GetManageProductPagingRequest request);
    }
}
