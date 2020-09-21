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
                productid = model.productid,
                supplierid = model.supplierid,
                importPrice = model.importPrice,
                Amount = model.Amount,
                total = model.Amount * model.importPrice
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
                               join p in context.Products on i.productid equals p.id
                               join s in context.Suppliers on i.supplierid equals s.id
                               select (new ListInventory()
                               {
                                   Amount = i.Amount,
                                   importPrice = i.importPrice,
                                   id = i.id,
                                   ProductName = p.ProductName,
                                   supplierName = s.Name,
                                   total = i.importPrice * i.Amount
                               }));
            return listInventories;
        }

        public int Update(Inventory model)
        {
            throw new NotImplementedException();
        }
    }
}
