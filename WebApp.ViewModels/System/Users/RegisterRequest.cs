using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.System.Users
{
    public class RegisterRequest
    {
        public string FirtName { set; get; }
        public string LastName { set; get; }
        public DateTime Dob { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
    }
}
