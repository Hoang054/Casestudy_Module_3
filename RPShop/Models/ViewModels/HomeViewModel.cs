using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels
{
    public class HomeViewModel
    {
        public Search Search { get; set; }
        public HomeView HomeView { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
