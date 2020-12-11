using Microsoft.AspNetCore.Mvc;
using RPShop.Models.ViewModels.Employee;
using RPShop.Services;

namespace RPShop.Controllers
{
    //[Authorize(Roles = "System Admin, Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeAdd model)
        {
            if (ModelState.IsValid)
            {
                
                var employeeId = employeeService.Create(model);
                if (employeeId > 0)
                {
                    return RedirectToAction("CreateEmployee", "Employee");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var create = new EmployeeAdd();
            return View(create);
        }
        [Route("/Employee/Delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var delEmployee = employeeService.Delete(id);
            return Json(new { delEmployee });
        }
        public IActionResult listEmployees()
        {
            return View();
        }
    }
}
