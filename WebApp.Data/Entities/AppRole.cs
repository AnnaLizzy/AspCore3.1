using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Decreption { get; set; }
    }
}
