
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateInventory
{
    public class ListInventory
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public double importPrice { get; set; }
        public string supplierName { get; set; }
        public double total { get; set; }
    }
}
