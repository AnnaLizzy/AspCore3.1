using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.Entities
{
    public class Admin : IdentityUser<Guid>
    {
        public string EmployNO { get; set; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
       
        [DataType(DataType.Date)]
        public DateTime Dob { set; get; }
        public List<Cart> Carts { set; get; }
        public List<Order> Orders { set; get; }
        public List<Transaction> Transactions { set; get; }
    }
}
