using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Applications.Dtos;

namespace WebApp.Applications.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }

    }
}
