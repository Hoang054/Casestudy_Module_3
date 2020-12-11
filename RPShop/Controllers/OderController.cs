using Microsoft.AspNetCore.Mvc;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Repository;
using System.Collections.Generic;
using System.Linq;

namespace RPShop.Controllers
{
    //[Authorize(Roles = "System Admin, Admin, Employee")]
    public class OderController : Controller
    {
        
        private readonly RPDbcontext context;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OderController(IOrderRepository orderRepository,
                            IProductRepository productRepository,
                            RPDbcontext context)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(orderRepository.Gets());
        }
        [HttpPost]
        [Route("Oder/ChangeStatus/{id}")]
        public JsonResult ChangeStatus(int id)
        {
            var result = orderRepository.ChangeStatus(id);
            return Json(new { result });
        }

        [Route("/Order/Delete/{id}")]
        public IActionResult Delete(int id)
        {

            if (orderRepository.DeleteOrder(id))
            {
                return RedirectToAction("Index", "Order");
            }
            return View();
        }
        public IActionResult RecycleBin()
        {
            var Categories = orderRepository.Gets();
            return View(Categories);
        }
        public IActionResult UndoDelete(int id)
        {
            if (orderRepository.UndoDelete(id) > 0)
            {
                return RedirectToAction("RecycleBin", "Order");
            }
            return View();

        }
        [Route("/Order/Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var order = orderRepository.GetOrder(id);
            return View(order);
        }
    }
}
