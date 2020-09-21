using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateOder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public interface IOderService
    {
        IEnumerable<OderView> GetOders();
        int CreateOrder(CreateOrder order);
        int CreateOrderDetail(OrderPrint orderPrint);
    }
}
