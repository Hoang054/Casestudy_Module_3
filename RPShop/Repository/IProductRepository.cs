using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public interface IProductRepository
    {
        int CreateProduct(Product product);
        //IEnumerable<ListToKhai> GetToKhais();
        Product GetProduct(int id);
        int DeleteProduct(int id);
        //int UpdateProduct(UpdateProduct model);
        IEnumerable<ListProduct> GetProducts();
    }
}
