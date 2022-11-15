using System.Collections.Generic;
using WebApp.ViewModels.Common;

namespace WebApp.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { set; get; }
        public List<int> CategoryIds { set; get; }
        public string LanguageId { get; set; }
    }
}
