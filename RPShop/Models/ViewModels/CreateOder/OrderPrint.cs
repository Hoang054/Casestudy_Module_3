using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateOder
{
    public class OrderPrint
    {
        //public int oderid { get; set; }

        public DateTime Date { get; set; }
        public ICollection<ListItems> Items { get; set; }

    }
}
