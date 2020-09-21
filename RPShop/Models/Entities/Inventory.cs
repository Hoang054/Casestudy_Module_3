using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Inventory
    {
        public int id { get; set; }
        [ForeignKey("Product")]
        public int productid { get; set; } 
        public int Amount { get; set; }
        public double importPrice { get; set; }
        [ForeignKey("Supplier")]
        public int supplierid { get; set; }
        public double total { get; set; }
        public Supplier supplier { get; set; }
        public Product product { get; set; }
    }
}
