using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateProduct;
using RPShop.Repository;

namespace RPShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISupplierRepository SupplierRepository;
        private readonly IWebHostEnvironment webHost;
        private readonly RPDbcontext context;
        private readonly IProductRepository productRepository;

        public ProductController(ISupplierRepository supplierRepository, IWebHostEnvironment webHost, 
                                    RPDbcontext context, IProductRepository productRepository)
        {
            SupplierRepository = supplierRepository;
            this.webHost = webHost;
            this.context = context;
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateSupplier()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSupplier(CreateSupplier model)
        {
            if (ModelState.IsValid)
            {
                var supplier = new Supplier()
                {
                    Email = model.Email,
                    Business_code = model.Business_code,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                };
                var suplierId = SupplierRepository.CreateSupplier(supplier);
                if (suplierId > 0)
                {
                    return RedirectToAction("CreateSupplier", "Product");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var createSuplier = new CreateSupplier();
            return View(createSuplier);
        }
        [Route("/Product/Delete/{id}")]
        public IActionResult DeteleSupplier(int id)
        {
            var deleSupplier = SupplierRepository.DeleteSupplier(id);
            return Json(new { deleSupplier });
        }
        public IActionResult ListSupplier()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult EditSupplier(int id)
        {
            var Supplier = SupplierRepository.GetSupplier(id);
            var SupplierEdit = new EditSupplier();
            if(Supplier != null)
            {
                SupplierEdit.id = Supplier.id;
                SupplierEdit.Email = Supplier.Email;
                SupplierEdit.Business_code = Supplier.Business_code;
                SupplierEdit.Name = Supplier.Name;
                SupplierEdit.PhoneNumber = Supplier.PhoneNumber;
            }
            return View(SupplierEdit);
        }
        [HttpPost]
        public IActionResult EditSupplier(UpdateSupplier model)
        {
            if (ModelState.IsValid)
            {
                if (SupplierRepository.UpdateSupplier(model) > 0)
                {
                    return RedirectToAction("ListSupplier", "Product");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var editSupplier = new EditSupplier();
            return View(editSupplier);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Create model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Detail = model.Detail,
                    idSupplier = model.idSupplier,
                    idType = model.idType,
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
                var productId = productRepository.CreateProduct(product);
                if(productId > 0)
                {
                    return RedirectToAction("Create", "Product");
                }

                //context.Products.Add(product);
                //context.SaveChanges();
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var createProduct = new Create();
            return View(createProduct);
        }
        public IActionResult ListProduct()
        {
            var product = new List<ListProduct>();
            product = productRepository.GetProducts().ToList();
            return View(product);
        }
    }
}
