using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.Common
{
    public class PagingRequestBase : RequestBase
    {
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
    }
}
