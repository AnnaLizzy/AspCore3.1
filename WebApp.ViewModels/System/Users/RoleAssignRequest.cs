using System;
using System.Collections.Generic;
using WebApp.ViewModels.Common;

namespace WebApp.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();

    }
}
