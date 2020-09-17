using RPShop.Models;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RPDbcontext context;

        public EmployeeService(RPDbcontext context)
        {
            this.context = context;
        }
        public int Create(Employees employees)
        {
            context.Employees.Add(employees);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var delEmployee = context.Employees.FirstOrDefault(e => e.id == id);
            if (delEmployee != null)
            {
                context.Employees.Remove(delEmployee);
                return context.SaveChanges();
            }
            return -1;
        }

        public Employees Get(int id)
        {
            return context.Employees.FirstOrDefault(e => e.id == id);
        }

        public int Update(Employees model)
        {
            var employee = Get(model.id);
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
