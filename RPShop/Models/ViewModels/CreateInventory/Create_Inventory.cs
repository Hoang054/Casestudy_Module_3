using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.ViewModels.CreateInventory
{
    public class Create_Inventory
    {
        public int productid { get; set; }
        public int Amount { get; set; }
        public double importPrice { get; set; }
        public int supplierid { get; set; }
        public double total { get; set; }
    }
}
