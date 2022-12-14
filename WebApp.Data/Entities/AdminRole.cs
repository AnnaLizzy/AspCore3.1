using Microsoft.AspNetCore.Identity;
using System;

namespace WebApp.Data.Entities
{
    public class AdminRole : IdentityRole<Guid>
    {
        
        public string Decreption { set; get; }
    }
}
