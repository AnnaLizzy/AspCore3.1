using System;
using System.Collections.Generic;
using System.Text;
using WebApp.ViewModels.Common;


namespace WebApp.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
          public int? CategoryId { get; set; }
    }
}
