using Microsoft.AspNetCore.Identity;
using System;

namespace WebApp.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Decreption { set; get; }
    }
}
