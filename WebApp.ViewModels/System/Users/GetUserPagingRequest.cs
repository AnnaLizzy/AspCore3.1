﻿using System;
using System.Collections.Generic;
using System.Text;
using WebApp.ViewModels.Common;

namespace WebApp.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
