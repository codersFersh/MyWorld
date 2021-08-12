using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWorldFront.ViewModels
{
    namespace MyWorldFront.ViewModels
    {
        public class AdminLoginVM
        {
            [Required]
            [Display(Name = "账号:")]
            public string PhoneNum { get; set; }


            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "密码:")]
            public string Password { get; set; }
        }
    }
}