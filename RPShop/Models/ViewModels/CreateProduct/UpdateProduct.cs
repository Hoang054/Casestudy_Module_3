using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateProduct
{
    public class UpdateProduct
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public IFormFile imagePath { get; set; }
        public IFormFile[] Images { get; set; }
        public string Detail { get; set; }
        public int Typeid { get; set; }
        public int Supplierid { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }
    }
}
