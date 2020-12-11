using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.Entities
{
    public class Vote
    {
        public int VoteId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int vote { get; set; }
    }
}
