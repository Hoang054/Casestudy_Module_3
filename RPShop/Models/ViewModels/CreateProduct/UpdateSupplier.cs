using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateProduct
{
    public class UpdateSupplier
    {
        public int id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "must enter the PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "must enter the Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Business_code { get; set; }
    }
}
