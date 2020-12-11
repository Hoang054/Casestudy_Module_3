using RPShop.Models;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly RPDbcontext context;

        public OrderDetailRepository(RPDbcontext context)
        {
            this.context = context;
        }
        public OrderDetail Get(int orderdetailId)
        {
            return context.OrderDetails.Find(orderdetailId);
        }

        public OrderDetail GetbyOrder(int orderid)
        {
            foreach (var item in context.OrderDetails)
            {
                if (item.OrderOnlineId == orderid)
                    return item;
            }
            return null;
        }

        public List<OrderDetail> Gets()
        {
            return context.OrderDetails.ToList();
        }

        public bool Insert(OrderDetail detail)
        {
            try
            {
                context.OrderDetails.Add(detail);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;

            }
        }
    }
}
