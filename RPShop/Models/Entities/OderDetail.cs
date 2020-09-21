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
        public int oderid { get; set; }
        [ForeignKey("Product"),Key]
        public int productid { get; set; }
        public int Quatity { get; set; }
        public int Discount { get; set; }
        public double UnitPrice { get; set; }
        //public DateTime OderDay { get; set; }
        public Product Product { get; set; }
        public Oder oder { get; set; }
    }
}
