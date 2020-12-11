﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageName { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
