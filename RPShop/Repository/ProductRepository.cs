using Microsoft.AspNetCore.Hosting;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateProduct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace RPShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly RPDbcontext context;
        private readonly IWebHostEnvironment webHost;

        public ProductRepository(RPDbcontext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }
        public int CreateProduct(Create model)
        {
            Product product = new Product()
            {
                Detail = model.Detail,
                supplierid = model.supplierid,
                typeProductid = model.typeProductid,
                Price = model.Price,
                ProductName = model.ProductName
            };
            string FileImage = null;
            if (model.imagePath != null)
            {
                string uploadsFolder = Path.Combine(webHost.WebRootPath, "images");
                FileImage = Guid.NewGuid().ToString() + "_" + model.imagePath.FileName;
                string filePath = Path.Combine(uploadsFolder, FileImage);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.imagePath.CopyTo(fileStream);
                }
            }
            product.imagePath = FileImage;
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
                        join s in context.Suppliers on p.supplierid equals s.id
                        join t in context.TypeProducts on p.typeProductid equals t.id
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
