using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateCustomer;
using RPShop.Services;

namespace RPShop.Controllers
{
    //[Authorize(Roles = "System Admin, Admin, Employee")]
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateCus()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateCustomer(CustomerView model)
        {
            if (ModelState.IsValid)
            {
                var customerId = customerService.Create(model);
                if(customerId > 0)
                {
                    return View();
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var createcustomer = new CustomerView();
            return View(createcustomer);
        }
        public IActionResult listCustomers()
        {
            return View();
        }
        [Route("/Customer/Delete/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var delCustomer = customerService.Delete(id);
            return Json(new { delCustomer});
        }
        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var customer = customerService.EditCustomer(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult EditCustomer(Customer model)
        {
            if (ModelState.IsValid)
            {
                if (customerService.Update(model) > 0)
                {
                    //return RedirectToAction("ListSupplier", "Product");
                    return View();
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var editCus = new EditCustomer();
            return View(editCus);
        }
    }
}
