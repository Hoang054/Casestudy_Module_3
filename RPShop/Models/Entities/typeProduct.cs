﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class typeProduct
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
