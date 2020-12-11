using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public interface IOrderDetailRepository
    {
        bool Insert(OrderDetail detail);
        OrderDetail Get(int orderdetailId);
        OrderDetail GetbyOrder(int idorder);
        List<OrderDetail> Gets();
    };
}
