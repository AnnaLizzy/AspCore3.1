using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Applications.Catalog.Products.Dtos;
using WebApp.Applications.Dtos;
using WebApp.Data.EF;
using WebApp.Data.Entities;

namespace WebApp.Applications.Catalog.Products
{
    public class ManageProductService : IManagerProductService
    {
        private readonly AppDbContext _context;
        public ManageProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int ProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
