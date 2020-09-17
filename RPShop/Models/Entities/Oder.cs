using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Oder
    {
        public int id { get; set; }
        [ForeignKey("Customer")]
        public int idCus { get; set; }
        [ForeignKey("Employees")]
        public int idEmployee { get; set; }
        public Employees employee { get; set; }
        public DateTime OderDay { get; set; }
        //public Oder oder { get; set; }
        public Customer customer { get; set; }
    }
}
