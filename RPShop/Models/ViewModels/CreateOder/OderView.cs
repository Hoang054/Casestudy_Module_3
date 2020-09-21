using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateOder
{
    public class OderView
    {
        public int Customer_id { get; set; }
        public int Employee_id { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        //public DateTime OderDay { get; set; }
        //public Employees employee { get; set; }
        //public Oder oder { get; set; }
        //public Customer customer { get; set; }
    }
}
