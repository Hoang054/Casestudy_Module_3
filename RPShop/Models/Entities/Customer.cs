using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Customer
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double totalPrice { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
