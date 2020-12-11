using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public interface IOrderRepository
    {
        int CreateOrder(OrderOnline order);
        IEnumerable<OrderOnline> Gets();
        bool DeleteOrder(int id);
        OrderOnline GetOrder(int id);
        int ChangeStatus(int id);
        int UndoDelete(int id);

    }
}
