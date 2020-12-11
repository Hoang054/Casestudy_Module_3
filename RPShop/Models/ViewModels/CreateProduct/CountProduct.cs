using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateProduct
{
    public class Countproduct
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string imagePath { get; set; }
        public string Detail { get; set; }
        public int Typeid { get; set; }
        public int count { get; set; }
        public int Supplierid { get; set; }
        public float Discount { get; set; }
    }
}
