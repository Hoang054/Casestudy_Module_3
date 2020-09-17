using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.Employee
{
    public class EmployeeAdd
    {
        public int id { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Department { get; set; }
        public IFormFile AvatarPath { get; set; }
    }
}
