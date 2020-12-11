using Microsoft.AspNetCore.Http;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateProduct
{
    public class EditProduct
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public List<Image> Images { get; set; }
        public string Detail { get; set; }
        public int Typeid { get; set; }
        public int Supplierid { get; set; }
        [Required]
        public string Description { get; set; }
        public float Discount { get; set; }
    }
}
