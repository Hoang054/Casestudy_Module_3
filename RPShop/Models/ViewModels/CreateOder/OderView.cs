using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateOder
{
    public class OderView
    {
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public Employees employee { get; set; }
        public DateTime OderDay { get; set; }
        //public Oder oder { get; set; }
        public Customer customer { get; set; }
    }
}
