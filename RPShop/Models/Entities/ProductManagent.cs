﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class ProductManagent
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public string productid { get; set; }
        public int amount { get; set; }
        public double Price { get; set; }
        public double total_revenue { get; set; }
        public double total_profit { get; set; }
        public ICollection<Employees> employee { get; set; }
        public Product product { get; set; }
    }
}
