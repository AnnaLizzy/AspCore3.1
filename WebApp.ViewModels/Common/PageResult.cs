using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.Common
{
    public class PageResult<T>
    {
        public List<T> Items { set; get; }
        public int TotalRecord { get; set; }
    }
}
