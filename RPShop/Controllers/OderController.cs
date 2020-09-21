using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPShop.Models;
using RPShop.Models.ViewModels.CreateOder;
using RPShop.Services;

namespace RPShop.Controllers
{
    public class OderController : Controller
    {
        private readonly IOderService oderService;

        public OderController(IOderService oderService)
        {
            this.oderService = oderService;
        }
        public IActionResult OrderPrint()
        {
            return View();
        }
        [HttpPost]
        [Route("/Oder/AddOrderAndOrderDetails")]
        public IActionResult AddOrderAndOrderDetails(OrderPrint orderPrint)
        {
            if (ModelState.IsValid)
            {
                //var order = new OrderPrint()
                //{
                //    Date = new DateTime(),
                //    Items = orderPrint
                //};
                var orderPrintId = oderService.CreateOrderDetail(orderPrint);
                if (orderPrintId > 0)
                {
                    return RedirectToAction("OrderPrint", "Oder");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var oderprint = new OrderPrint();
            return View(orderPrint);
        }
        public IActionResult CreateOder()
        {
            var Orders = new List<OderView>();
            Orders = oderService.GetOders().ToList();
            return View(Orders);
        }
        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrder(CreateOrder createOrder)
        {
            if (ModelState.IsValid)
            {
                var orderId = oderService.CreateOrder(createOrder);
                if(orderId > 0)
                {
                    return RedirectToAction("CreateOrder", "Oder");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var CreateOrder = new CreateOrder();
            return View(CreateOrder);
        }
    }
}
