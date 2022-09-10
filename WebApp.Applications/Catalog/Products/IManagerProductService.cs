using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Applications.Catalog.Products.Dtos;
using WebApp.Applications.Dtos;

namespace WebApp.Applications.Catalog.Products
{
    public interface IManagerProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductEditRequest request);
        Task<int> Delete(int ProductId);
        Task<List<ProductViewModel>> GetAll();
        Task<PageViewModel<ProductViewModel>>GetAllPaging(string keyword,
            int pageIndex,int pageSize);
    }
}
