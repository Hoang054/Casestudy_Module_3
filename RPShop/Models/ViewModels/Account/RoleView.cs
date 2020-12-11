using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.Account
{
    public class RoleView
    {
        [Required]
        public string RoleName { get; set; }
    }
}
