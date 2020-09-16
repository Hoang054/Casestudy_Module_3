using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels;

namespace RPShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                var product = new Product()
                {
                    Detail = model.Detail,
                    idSupplier = model.idSupplier,
                    idType = model.idType,
                    imagePath = model.imagePath,
                    Price = model.Price,
                    ProductName = model.ProductName,

                };
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreatetypeProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatetypeProduct(createType model)
        {
            if (ModelState.IsValid)
            {
                var type = new typeProduct()
                {
                    Name = model.Name
                };
            }
            return View();
        }
    }
}
