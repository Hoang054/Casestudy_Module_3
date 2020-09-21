using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateCustomer;
using RPShop.Models.ViewModels.CreateProduct;
using RPShop.Services;

namespace RPShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(CustomerView model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    FullName = model.FullName,
                    Address = model.Address,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                var customerId = customerService.Create(customer);
                if(customerId > 0)
                {
                    return RedirectToAction("CreateCustomer", "Customer");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var createcustomer = new CustomerView();
            return View(createcustomer);
        }
    }
}
