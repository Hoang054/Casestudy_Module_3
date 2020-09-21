using Microsoft.EntityFrameworkCore;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateOder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public class OderService : IOderService
    {
        private readonly RPDbcontext context;

        public OderService(RPDbcontext context)
        {
            this.context = context;
        }

        public int CreateOrder(CreateOrder model)
        {
            var order = new Oder()
            {
                cutomer_id = model.cutomerid,
                employeeid = model.employeeid,
                OderDay = model.OderDay
            };
            context.Oders.Add(order);
            return context.SaveChanges();
        }

        public int CreateOrderDetail(OrderPrint orderPrint)
        {
            var order = new Oder()
            {
                OderDay = orderPrint.Date,
            };
            context.Oders.Add(order);
            if (context.SaveChanges() > 0)
            {
                int orderId = context.Oders.Max(e => e.id);
                foreach(var item in orderPrint.Items)
                {
                    var OderDetail = new OderDetail()
                    {
                        oderid = orderId,
                        productid = item.productid,
                        UnitPrice = item.TotalPrice,
                        Quatity = item.Quantiy
                    };
                    context.OderDetails.Add(OderDetail);
                }
            }
            return context.SaveChanges();
        }

        public IEnumerable<OderView> GetOders()
        {
            IEnumerable<OderView> Order = new List<OderView>();
            Order = (from p in context.Products
                     join i in context.Inventorys on p.id equals i.productid
                     //join c in context.Customers on o. equals
                     select (new OderView()
                     {
                         ProductName = p.ProductName,
                         Amount = i.Amount,
                         Price = p.Price
                     }));
            return Order;
        }
    }
}
