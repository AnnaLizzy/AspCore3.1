using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using WebApp.Data.Entities;

namespace webapp.data.entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Dob { get; set; }

        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
