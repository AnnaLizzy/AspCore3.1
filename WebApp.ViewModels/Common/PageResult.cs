using System;
using System.Collections.Generic;
using WebApp.ViewModels.Catalog.Card;

namespace WebApp.ViewModels.Common
{
    public class PageResult<T> : PageResultBase
    {
        public List<T> Items { set; get; }

        public static implicit operator PageResult<T>(PageResult<CardViewModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
