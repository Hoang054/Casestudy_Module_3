using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int TypeProduct_id { get; set; }
        public int Supplierid { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string ImagePath { get; set; }
        public List<Image> Images { get; set; }
        public string Detail { get; set; }

        public TypeProduct TypeProduct { get; set; }

        public float Discount { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Supplier supplier { get; set; }
    }
}
