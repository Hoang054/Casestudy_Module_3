using Microsoft.AspNetCore.Components.Forms;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateCustomer
{
    public class CustomerView : CreateCustomer
    {
        public CustomerView()
        {
            Products = new List<Product>();
        }
        public int id { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
