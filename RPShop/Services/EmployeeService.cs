using Microsoft.AspNetCore.Hosting;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RPDbcontext context;
        private readonly IWebHostEnvironment webHost;

        public EmployeeService(RPDbcontext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }
        public int Create(EmployeeAdd model)
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
            context.Employees.Add(employee);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var delEmployee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (delEmployee != null)
            {
                context.Employees.Remove(delEmployee);
                return context.SaveChanges();
            }
            return -1;
        }

        public Employees Get(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public int Update(Employees model)
        {
            var employee = Get(model.Id);
            if(employee == null)
            {
                return -1;
            }
            employee.AvatarPath = model.AvatarPath;
            employee.Department = model.Department;
            employee.Email = model.Email;
            employee.FullName = model.FullName;
            employee.PhoneNumber = model.PhoneNumber;
            context.Update(employee);
            return context.SaveChanges();
        }
    }
}
