using Microsoft.AspNetCore.Http;
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
        int CreateProduct(Create model, IFormFile[] ImageFiles);
        //IEnumerable<ListToKhai> GetToKhais();
        Product GetProduct(int id);
        Product Get(int id);
        int DeleteProduct(int id);
        int UpdateProduct(UpdateProduct model, IFormFile[] ImageFiles);
        IEnumerable<ListProduct> GetProducts();
        List<Countproduct> GetCount();
        EditProduct EditProduct(int id);
    }
}
