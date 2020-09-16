using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class ProductManagent
    {
        public int id { get; set; }
        [ForeignKey("Product")]
        public string idProduct { get; set; }
        public int amount { get; set; }
        public double Price { get; set; }
        public decimal discount { get; set; }
        public double surcharge { get; set; }
        public double total { get; set; }
        public ICollection<Employees> employee { get; set; }
        public Product product { get; set; }

    }
}
