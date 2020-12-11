using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.ViewModels.CreateInventory
{
    public class Create_Inventory
    {
        [Required]
        [Display(Name = "Sản Phẩm")]
        public int productid { get; set; }
        [Required]
        [Display(Name = "Số Lượng")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Amount { get; set; }
        [Required]
        [Display(Name = "Giá nhập")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double importPrice { get; set; }
        [Required]
        [Display(Name = "Nhà Cung Cấp")]
        public int supplierid { get; set; }
        [Required]
        [Display(Name = "Tổng cộng")]
        public double total { get; set; }
    }
}
