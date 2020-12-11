using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Inventory
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        //[ForeignKey("Supplier")]
        public int Supplierid { get; set; }
        public int Amount { get; set; }
        public double ImportPrice { get; set; }


        public double Total { get; set; }
        //public Supplier supplier { get; set; }
        public Product product { get; set; }
    }
}
