using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels
{
    public class HomeView
    {
        public List<Product> products { get; set; }
        public List<Product> productssale { get; set; }
        public Product Product { get; set; }
        public List<Product> bestbuyproducts { get; set; }
        public List<TypeProduct> TypeProduct { get; set; }
    }
}
