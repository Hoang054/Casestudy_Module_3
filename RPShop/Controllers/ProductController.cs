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
        private readonly ISupplierRepository supplierRepository;
        private readonly IProductRepository productRepository;

        public ProductController(ISupplierRepository supplierRepository,
                                    RPDbcontext context, IProductRepository productRepository)
        {
            this.supplierRepository = supplierRepository;
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
        public IActionResult CreateSupplier(Supplier model)
        {
            if (ModelState.IsValid)
            {
                var suplierId = supplierRepository.CreateSupplier(model);
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
            var deleSupplier = supplierRepository.DeleteSupplier(id);
            return Json(new { deleSupplier });
        }
        public IActionResult ListSupplier()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult EditSupplier(int id)
        {
            var Supplier = supplierRepository.GetSupplier(id);
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
                if (supplierRepository.UpdateSupplier(model) > 0)
                {
                    return RedirectToAction("ListSupplier", "Product");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var editSupplier = new EditSupplier();
            return View(editSupplier);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Create model)
        {
            if (ModelState.IsValid)
            {
                var productId = productRepository.CreateProduct(model);
                if(productId > 0)
                {
                    return RedirectToAction("CreateProduct", "Product");
                }
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
