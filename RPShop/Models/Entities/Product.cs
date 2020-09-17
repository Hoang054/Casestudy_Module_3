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
        [ForeignKey("TypeProduct")]
        public int idType { get; set; }
        [ForeignKey("Supplier")]
        public int idSupplier { get; set; }
        public TypeProduct typeProduct { get; set; }
        public Supplier supplier { get; set; }
    }
}
