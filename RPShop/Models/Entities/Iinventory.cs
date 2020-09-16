using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Iinventory
    {
        public int id { get; set; }
        [ForeignKey("Product")]
        public string idProduct { get; set; }
        public int Amount { get; set; }
        public double importPrice { get; set; }
        [ForeignKey("supplier")]
        public int idsupplier { get; set; }
        public supplier supplier { get; set; }
        public Product product { get; set; }
    }
}
