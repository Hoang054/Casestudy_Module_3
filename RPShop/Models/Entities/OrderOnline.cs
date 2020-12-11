using RPShop.Models.ViewModels.CreateOder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class OrderOnline
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string CreatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string ShipName { get; set; }
        [Required]
        [StringLength(50)]
        public string ShipPhoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string ShipAddress { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        public bool Status { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Customer Customer { get; set; }
    }
}
