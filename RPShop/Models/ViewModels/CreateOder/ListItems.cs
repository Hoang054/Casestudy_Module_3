using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateOder
{
    public class ListItems
    {
        public int productid { get; set; }
        public double Price { get; set; }
        public int Quantiy { get; set; }
        public double TotalPrice { get; set; }
    }
}
