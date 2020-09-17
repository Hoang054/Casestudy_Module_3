using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateProduct
{
    public class ListProduct
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string imagePath { get; set; }
        public string Detail { get; set; }
        public string TypeName { get; set; }
        public string SupplierName { get; set; }
    }
}
