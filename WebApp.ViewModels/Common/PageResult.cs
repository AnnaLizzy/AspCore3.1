using System.Collections.Generic;

namespace WebApp.ViewModels.Common
{
    public class PageResult<T> : PageResultBase
    {
        public List<T> Items { set; get; }
        
    }
}
