using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly RPDbcontext context;

        public InventoryService(RPDbcontext context)
        {
            this.context = context;
        }
        public int Create(Inventory model)
        {
            var inventory = new Inventory()
            {
                ProductId = model.ProductId,
                Supplierid = model.Supplierid,
                ImportPrice = model.ImportPrice,
                Amount = model.Amount,
                Total = model.Amount * model.ImportPrice
            };
            context.Inventorys.Add(inventory);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Inventory Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListInventory> Gets()
        {
            IEnumerable<ListInventory> listInventories = new List<ListInventory>();
            listInventories = (from i in context.Inventorys
                               join p in context.Products on i.ProductId equals p.Id
                               join s in context.Suppliers on i.Supplierid equals s.Id
                               select (new ListInventory()
                               {
                                   Amount = i.Amount,
                                   importPrice = i.ImportPrice,
                                   id = i.Id,
                                   ProductName = p.ProductName,
                                   supplierName = s.Name,
                                   total = i.ImportPrice * i.Amount
                               }));
            return listInventories;
        }

        public int Update(Inventory model)
        {
            throw new NotImplementedException();
        }
    }
}
