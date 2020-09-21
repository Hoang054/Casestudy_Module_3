using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateOder
{
    public class CreateOrder
    {
        public int cutomerid { get; set; }
        public int employeeid { get; set; }
        public DateTime OderDay { get; set; }
    }
}
