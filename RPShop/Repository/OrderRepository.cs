using RPShop.Models;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RPDbcontext context;

        public OrderRepository(RPDbcontext context)
        {
            this.context = context;
        }
        public int ChangeStatus(int id)
        {
            var order = GetOrder(id);
            if (order.Status == true)
                order.Status = false;
            else
                order.Status = true;
            return context.SaveChanges();
        }

        public int CreateOrder(OrderOnline order)
        {
            var result = context.OrderOnlines.Add(order);
            //order.ID = result.Entity.ID;
            return context.SaveChanges();
        }

        public bool DeleteOrder(int id)
        {
            var order = GetOrder(id);
            if (order != null)
            {
                order.IsDelete = true;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public OrderOnline GetOrder(int id)
        {
            return context.OrderOnlines.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<OrderOnline> Gets()
        {
            return context.OrderOnlines.ToList();
        }

        public int UndoDelete(int id)
        {
            var order = GetOrder(id);
            order.IsDelete = false;
            return context.SaveChanges();
        }
    }
}
