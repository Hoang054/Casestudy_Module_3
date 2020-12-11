using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateProduct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        public int CreateProduct(Create model, IFormFile[] ImageFiles)
        {
            Product product = new Product()
            {
                Detail = model.Detail,
                Supplierid = model.supplierid,
                TypeProduct_id = model.typeProductid,
                Price = model.Price,
                ProductName = model.ProductName,
                Description = model.Description,
                Discount = model.Discount
            };
            string FileImage = null;
            if (model.ImagePath != null)
            {
                string uploadsFolder = Path.Combine(webHost.WebRootPath, "images");
                FileImage = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                string filePath = Path.Combine(uploadsFolder, FileImage);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(fileStream);
                }
            }
            product.ImagePath = FileImage;

            List<Image> images = new List<Image>();
            if (ImageFiles != null)
            {
                var iamge = ImageFiles.ToList();
                string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
                for (int i = 0; i < iamge.Count; i++)
                {
                    string fileName = $"{Guid.NewGuid()}_{iamge[i].FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        iamge[i].CopyTo(fs);
                    }
                    var anh = new Image()
                    {
                        ProductId = model.ProductId,
                        ImageName = fileName
                    };
                    images.Add(anh);
                }
            }
            else
            {
                var no_anh = new Image()
                {
                    ProductId = model.ProductId,
                    ImageName = "avatar1.jpg"
                };
                images.Add(no_anh);
            }
            product.Images = images;
            context.Products.Add(product);
            return context.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            var delProduct = GetProduct(id);
            if(delProduct != null)
                context.Products.Remove(delProduct);
            return context.SaveChanges();
        }

        public EditProduct EditProduct(int id)
        {
            var product = GetProduct(id);
            var productEdit = new EditProduct();
            if (product != null)
            {
                
                productEdit.id = product.Id;
                productEdit.ImagePath = product.ImagePath;
                productEdit.Images = product.Images;
                productEdit.Description = product.Description;
                productEdit.Price = product.Price;
                productEdit.ProductName = product.ProductName;
                productEdit.Supplierid = product.Supplierid;
                productEdit.Typeid = product.TypeProduct_id;
                productEdit.Detail = product.Detail;
            }
            return productEdit;
        }

        public List<Countproduct> GetCount()
        {
            List<Countproduct> countproducts = new List<Countproduct>();
            foreach (var product in context.Products.ToList())
            {
                var product1 = new Countproduct();
                var count1 = 0; 
                foreach (var oder in context.OrderDetails.ToList())
                {
                    if (oder.ProductId == product.Id)
                    {
                        count1 += oder.Quantity;
                    }
                }
                product1 = new Countproduct()
                {
                    count = count1,
                    Detail = product.Detail,
                    id = product.Id,
                    imagePath = product.ImagePath,
                    Price = product.Price,
                    ProductName = product.ProductName,
                    Supplierid = product.Supplierid,
                    Typeid =product.TypeProduct_id,
                    Discount = product.Discount
                };
                countproducts.Add(product1);
            }
            var tam = countproducts.OrderByDescending(e => e.count).ToList();
            return tam;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            List<Image> list = new List<Image>();
            foreach(var item in context.Images)
            {
                if (item.ProductId == id)
                {
                    list.Add(item);
                }
            }
            product = context.Products.FirstOrDefault(e => e.Id == id);
            product.Images = list;
            return product;
        }
        public Product Get(int id)
        {
            Product product = new Product();
            product = context.Products.FirstOrDefault(e => e.Id == id);
            return product;
        }

        public IEnumerable<ListProduct> GetProducts()
        {
            IEnumerable<ListProduct> products = new List<ListProduct>();
            products = (from p in context.Products
                        join s in context.Suppliers on p.Supplierid equals s.Id
                        join t in context.TypeProducts on p.TypeProduct_id equals t.Id
                        select (new ListProduct()
                        {
                            id = p.Id,
                            Detail = p.Detail,
                            imagePath = p.ImagePath,
                            Price = p.Price,
                            ProductName = p.ProductName,
                            SupplierName = s.Name,
                            TypeName = t.Name
                        }));
            return products;
        }

        public int UpdateProduct(UpdateProduct model, IFormFile[] ImageFiles)
        {
            var product = GetProduct(model.id);
            if (product == null)
            {
                return -1;
            }
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
            product.ImagePath = FileImage;
            }

            List<Image> images = new List<Image>();
            if (ImageFiles.Length > 0)
            {
                var iamge = ImageFiles.ToList();
                string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
                for (int i = 0; i < iamge.Count; i++)
                {
                    string fileName = $"{Guid.NewGuid()}_{iamge[i].FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        iamge[i].CopyTo(fs);
                    }
                    var anh = new Image()
                    {
                        ProductId = model.id,
                        ImageName = fileName
                    };
                    images.Add(anh);
                }
                product.Images = images;
            }

            product.Id = model.id;
            product.Price = model.Price;
            product.ProductName = model.ProductName;
            product.Supplierid = model.Supplierid;
            product.TypeProduct_id = model.Typeid;
            product.Detail = model.Detail;
            
            product.Description = model.Description;
            product.Discount = model.Discount;
            context.Products.Update(product);
            return context.SaveChanges();
        }
    }
}
