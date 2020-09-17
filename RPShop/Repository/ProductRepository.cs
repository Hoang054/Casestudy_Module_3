using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace RPShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly RPDbcontext context;

        public ProductRepository(RPDbcontext context)
        {
            this.context = context;
        }
        public int CreateProduct(Product product)
        {
            context.Products.Add(product);
            return context.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            var delProduct = GetProduct(id);
            context.Products.Remove(delProduct);
            return context.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(e => e.id == id);
        }

        public IEnumerable<ListProduct> GetProducts()
        {
            IEnumerable<ListProduct> products = new List<ListProduct>();
            products = (from p in context.Products
                        join s in context.Suppliers on p.idSupplier equals s.id
                        join t in context.TypeProducts on p.idType equals t.id
                        select (new ListProduct()
                        {
                            id = p.id,
                            Detail = p.Detail,
                            imagePath = p.imagePath,
                            Price = p.Price,
                            ProductName = p.ProductName,
                            SupplierName = s.Name,
                            TypeName = t.Name
                        }));
            return products;
        }
    }
}
