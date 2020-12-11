using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class OrderDetail
    {
        [ForeignKey("OrderOnline")]
        public int OrderOnlineId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public double UnitPrice { get; set; }
        //public DateTime OderDay { get; set; }
        public Product Product { get; set; }
        public OrderOnline OrderOnline { get; set; }
    }
}
