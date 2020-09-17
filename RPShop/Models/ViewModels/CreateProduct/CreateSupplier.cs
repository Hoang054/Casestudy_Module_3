using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RPShop.Models.Entities;

namespace RPShop.Models.ViewModels.CreateProduct
{
    public class CreateSupplier
    {
        public CreateSupplier()
        {
            Products = new List<Product>();
        }
        [Required(ErrorMessage = "must enter the name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "must enter the PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "must enter the Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Business_code { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
