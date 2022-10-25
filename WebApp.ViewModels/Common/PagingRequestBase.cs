using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.Common
{
    public class PagingRequestBase
    {
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
    }
}
