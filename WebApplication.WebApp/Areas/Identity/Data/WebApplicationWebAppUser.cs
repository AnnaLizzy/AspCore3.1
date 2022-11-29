using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication.WebApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the WebApplicationWebAppUser class
    public class WebApplicationWebAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
    }
}
