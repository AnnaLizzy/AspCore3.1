using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.Common
{
    public class PageResultBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 1;
        public int TotalRecords { get; set; }
        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalRecords / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
