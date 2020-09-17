using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public interface IEmployeeService
    {
        int Create(Employees t);
        int Delete(int id);
        int Update(Employees model);
        Employees Get(int id);
    }
}
