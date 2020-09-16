using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Product
    {
        public int id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string imagePath { get; set; }
        public string Detail { get; set; }
        [ForeignKey("typeProduct")]
        public int idType { get; set; }
        [ForeignKey("supplier")]
        public int idSupplier { get; set; }
        public typeProduct typeProduct { get; set; }
        public supplier supplier { get; set; }
    }
}
