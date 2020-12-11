using Microsoft.AspNetCore.Http;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateProduct
{
    public class Create
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "must enter the fullname")]
        [MaxLength(30)]
        [Display(Name ="Tên Sản Phẩm")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "must enter the Price")]
        [Display(Name ="Giá Bán")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public float Price { get; set; }
        [Display(Name ="Ảnh")]
        public IFormFile[] Images { get; set; }
        public IFormFile ImagePath { get; set; }
        [Display(Name ="Chi Tiết")]
        public string Detail { get; set; }
        [Required(ErrorMessage = "must enter the type")]
        [Display(Name ="Kiểu Sản phẩm")]
        public int typeProductid { get; set; }
        [Display(Name ="Nhà Cung Cấp")]
        public int supplierid { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public string Description { get; set; }
        public float Discount { get; set; }
    }
}
