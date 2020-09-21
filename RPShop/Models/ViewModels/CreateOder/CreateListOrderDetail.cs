using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateOder
{
    public class CreateListOrderDetail
    {
        public int oderid { get; set; }
        public int productid { get; set; }
        public int Quatity { get; set; }
        public int Discount { get; set; }
        public double UnitPrice { get; set; }
    }
}
