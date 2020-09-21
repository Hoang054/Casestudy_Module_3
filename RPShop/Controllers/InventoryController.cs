using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateInventory;
using RPShop.Services;
using RPShop.ViewModels.CreateInventory;

namespace RPShop.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateInventory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInventory(Inventory model)
        {
            if (ModelState.IsValid)
            {
                var inventoryId = inventoryService.Create(model);
                if (inventoryId > 0)
                {
                    return RedirectToAction("CreateInventory", "Inventory");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var create = new Create_Inventory();
            return View(create);
        }
        public IActionResult ListInventory()
        {
            var inventorys = new List<ListInventory>();
            inventorys = inventoryService.Gets().ToList();
            return View(inventorys);
        }
    }
}
