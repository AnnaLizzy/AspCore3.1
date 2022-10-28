using System.Collections.Generic;

namespace WebApp.ViewModels.Common
{
    public class PageResult<T>
    {
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; }
    }
}
