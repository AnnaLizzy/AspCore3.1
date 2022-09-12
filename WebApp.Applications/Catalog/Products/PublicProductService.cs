using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Applications.Catalog.Products.Dtos;
using WebApp.Applications.Catalog.Products.Dtos.Manage;
using WebApp.Applications.Catalog.Products.Dtos.Public;
using WebApp.Applications.Dtos;
using WebApp.Data.EF;
using WebApp.Data.Entities;
using GetProductPagingRequest = WebApp.Applications.Catalog.Products.Dtos.Manage.GetProductPagingRequest;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Applications.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly AppDbContext _context;
        public PublicProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PageResult<ProductViewModel>> GetAllByCategory(Dtos.Public.GetProductPagingRequest request)
        {        
            //1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            //2. Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.PageSize );
            }
            //3.Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex = 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginPrice = x.p.OriginPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                }).ToListAsync();
            //4. Select and Projection
            var pagedResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pagedResult;
        }
    }
}
