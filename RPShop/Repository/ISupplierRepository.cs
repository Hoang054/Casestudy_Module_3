using RPShop.Models.Entities;
using RPShop.Models.ViewModels;
using RPShop.Models.ViewModels.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public interface ISupplierRepository
    {
        int CreateSupplier(Supplier supplier);
        //IEnumerable<ListToKhai> GetToKhais();
        Supplier GetSupplier(int id);
        int DeleteSupplier(int id);
        int UpdateSupplier(UpdateSupplier model);
        EditSupplier EditSupplier(int id);
    }
}
