using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp.ViewModels.Common;

namespace WebApp.ViewModels.System.Users
{
    public class UserVM
    {
        public Guid Id { get; set; }
        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Display(Name = "Só điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Người dùng")]
        public string UserName { get; set; }


        public string Email { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime Dob { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }        

        public IList<string> Roles { get; set; }
    }
}
