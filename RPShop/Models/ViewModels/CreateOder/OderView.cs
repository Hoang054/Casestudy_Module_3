using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateOder
{
    public class OderView
    {
        public int orderid { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ProductName { get; set; }

        //public DateTime OderDay { get; set; }
        //public Employees employee { get; set; }
        //public Oder oder { get; set; }
        //public Customer customer { get; set; }
    }

    public class ListItem
    {
        public string productName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
