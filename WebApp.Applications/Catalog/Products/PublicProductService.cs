using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.EF;
using WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.Catalog.Products;


namespace WebApp.Applications.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly AppDbContext _context;
        public PublicProductService(AppDbContext context)
        {
            _context = context;
        }

        public Task<PageResult<ProductViewModel>> GetAllCategoryById(GetManageProductPagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
