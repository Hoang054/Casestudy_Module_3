using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public interface IInventoryService : IService<Inventory>
    {
        int Create(Inventory model);
        IEnumerable<ListInventory> Gets();
    }
}
