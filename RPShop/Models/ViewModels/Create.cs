using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels
{
    public class Create
    {
        public Create()
        {
            typeProducts = new List<typeProduct>();
            suppliers = new List<supplier>();
        }
        public int id { get; set; }
        [Required(ErrorMessage = "must enter the fullname")]
        [MaxLength(30)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "must enter the Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "must enter the path")]
        public string imagePath { get; set; }
        public string Detail { get; set; }
        [Required(ErrorMessage = "must enter the type")]
        public int idType { get; set; }
        public int idSupplier { get; set; }
        public IEnumerable<typeProduct> typeProducts { get; set; }
        public IEnumerable<supplier> suppliers { get; set; }
    }
}
