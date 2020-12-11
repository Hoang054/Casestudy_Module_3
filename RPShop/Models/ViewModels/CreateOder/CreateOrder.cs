using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.CreateOder
{
    public class CreateOrder
    {
        [Display(Name ="Tên Khách Hàng")]
        public int cutomerid { get; set; }
        [Display(Name ="Tên Nhân Viên")]
        public int employeeid { get; set; }
        [Display(Name ="Ngày Giao dịch")]
        
        public DateTime OderDay { get; set; }
    }
}
