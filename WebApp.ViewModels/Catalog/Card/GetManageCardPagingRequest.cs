using System;
using System.Collections.Generic;
using System.Text;
using WebApp.ViewModels.Common;

namespace WebApp.ViewModels.Catalog.Card
{
    public class GetManageCardPagingRequest : PagingRequestBase
    {
        public string Keyword { set; get; }
    }
}
