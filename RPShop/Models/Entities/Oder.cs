using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Oder
    {
        [ForeignKey("OderDetail")]
        public int idOder { get; set; }
        [ForeignKey("Customer")]
        public int idCus { get; set; }
        public DateTime OderDay { get; set; }
        public Oder oder { get; set; }
        public Customer customer { get; set; }
    }
}
