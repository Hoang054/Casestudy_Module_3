using Microsoft.AspNetCore.Http;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateProduct
{
    public class Create
    {
        [Required(ErrorMessage = "must enter the fullname")]
        [MaxLength(30)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "must enter the Price")]
        public double Price { get; set; }
        public IFormFile imagePath { get; set; }
        public string Detail { get; set; }
        [Required(ErrorMessage = "must enter the type")]
        public int typeProductid { get; set; }
        public int supplierid { get; set; }
    }
}
