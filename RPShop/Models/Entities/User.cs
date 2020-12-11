using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Display(Name = "Số điện thoại")]
        [RegularExpression("(09|01[2|6|8|9])+([0-9]{8})", ErrorMessage = "Số điện thoại không đúng")]
        public string numberPhone { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Display(Name = "Xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }

        public string AvatarPath { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
