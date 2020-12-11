using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels;
using RPShop.Repository;
using System.Diagnostics;

namespace RPShop.Controllers
{
    //[Authorize(Roles = "System Admin, Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITypeProductRepository iTypeProductRepository;

        public HomeController(ILogger<HomeController> logger, ITypeProductRepository iTypeProductRepository)
        {
            _logger = logger;
            this.iTypeProductRepository = iTypeProductRepository;
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
        public IActionResult CreatetypeProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatetypeProduct(createType model)
        {
            if (ModelState.IsValid)
            {
                var type = new TypeProduct()
                {
                    Name = model.Name
                };
                var typeId = iTypeProductRepository.Create(type);
                if(typeId > 0)
                {
                    return RedirectToAction("ListType", "Home");
                }

                ModelState.AddModelError("", "System error, please try again later!");

            }
            var createType = new createType();
            return View(createType);
        }
        [Route("/Home/Delete/{id}")]
        public IActionResult DeleteToKhai(int id)
        {
            var deleType = iTypeProductRepository.Delete(id);
            return Json(new { deleType });
        }
        public IActionResult listType()
        {
        //    var type = new List<typeProduct>();
        //    type = context.typeProducts.ToList();
            return View();
        }
    }
}
