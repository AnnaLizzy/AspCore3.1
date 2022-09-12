using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Applications.Dtos;

namespace WebApp.Applications.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int CategoryId { get; set; }
    }
}
