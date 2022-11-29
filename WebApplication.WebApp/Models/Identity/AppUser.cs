using Microsoft.AspNetCore.Identity;
using System;

namespace WebApplication.WebApp.Models.Identity
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }

        [PersonalData]
        public string Description { get; set; }

        [PersonalData]
        public DateTime? BirthDate { get; set; }
    }
}
