using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateProduct;
using RPShop.Repository;
using X.PagedList;

namespace RPShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly RPDbcontext context;
        private readonly IProductRepository productRepository;

        public ProductController(ISupplierRepository supplierRepository,
                                    RPDbcontext context, IProductRepository productRepository)
        {
            this.supplierRepository = supplierRepository;
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
            var Supplier = supplierRepository.EditSupplier(id);
            return View(Supplier);
        }
        [HttpPost]
        public IActionResult EditSupplier(UpdateSupplier model)
        {
            if (ModelState.IsValid)
            {
                if (supplierRepository.UpdateSupplier(model) > 0)
                {
                    //return RedirectToAction("ListSupplier", "Product");
                    return View();
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
        public IActionResult CreateProduct(Create model, IFormFile[] ImageFiles)
        {
            if (ModelState.IsValid)
            {
                var productId = productRepository.CreateProduct(model, ImageFiles);
                if(productId > 0)
                {
                    return RedirectToAction("ListProduct", "Product");
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
        [AllowAnonymous]
        public IActionResult List(string search)
        {
            //var product = productRepository.GetCount().ToList();
            //product = productRepository.GetProducts().Where(e => e.ProductName.Contains(search)|| search == null).ToList();
            var product = context.Products.Where(e => e.ProductName.Contains(search)|| search == null).ToList();
            //product1 = productRepository.GetCount().ToList();
            return View(product);
            //return View();
        }
        [AllowAnonymous]
        [Route("/Product/Listtype/{id}")]
        public IActionResult Listtype(string search,int id, int? page)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            var product1 = context.Products.Where(e => e.ProductName.Contains(search) || search == null).ToList();
            product1 = product1.Where(e => e.TypeProduct_id == id).ToList();
            var result = product1.ToPagedList(pageNumber, pageSize);
            return View(result);
            //return View();
        }
        [Route("/Product/DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var delProduct = productRepository.DeleteProduct(id);
            return Json(new { delProduct });
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = productRepository.EditProduct(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(UpdateProduct model, IFormFile[] ImageFiles)
        {
            if (ModelState.IsValid)
            {
                if (productRepository.UpdateProduct(model, ImageFiles) > 0)
                {
                    return RedirectToAction("ListProduct", "Product");
                    //return Ok(true);
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var editProduct = new EditProduct();
            return View(editProduct);
        }
        [AllowAnonymous]
        [Route("/Prodcut/Details/{id}")]
        public IActionResult Details(int id)
        {
            var product = productRepository.GetProduct(id);
            return View(product);
        }
    }
}
