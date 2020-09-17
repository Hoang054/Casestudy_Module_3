using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.Employee;
using RPShop.Services;

namespace RPShop.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly RPDbcontext context;
        private readonly IWebHostEnvironment webHost;

        public EmployeeController(IEmployeeService employeeService,
                                    RPDbcontext context, IWebHostEnvironment webHost)
        {
            this.employeeService = employeeService;
            this.context = context;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeAdd model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employees()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Department = model.Department
                };
                string FileImage = null;
                if (model.AvatarPath != null)
                {
                    string uploadsFolder = Path.Combine(webHost.WebRootPath, "images");
                    FileImage = Guid.NewGuid().ToString() + "_" + model.AvatarPath.FileName;
                    string filePath = Path.Combine(uploadsFolder, FileImage);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.AvatarPath.CopyTo(fileStream);
                    }
                }
                employee.AvatarPath = FileImage;
                var employeeId = employeeService.Create(employee);
                if (employeeId > 0)
                {
                    return RedirectToAction("CreateEmployee", "Employee");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var create = new EmployeeAdd();
            return View(create);
        }
    }
}
