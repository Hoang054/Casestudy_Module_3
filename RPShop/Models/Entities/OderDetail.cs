using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class OderDetail
    {
        [ForeignKey("Oder"), Key]
        public int idOder { get; set; }
        [ForeignKey("Product"),Key]
        public int idProduct { get; set; }
        
        public int Quantity { get; set; }

        public int Discount { get; set; }
        public double Surcharge { get; set; }
        public Product Product { get; set; }
        public Oder oder { get; set; }
    }
}
