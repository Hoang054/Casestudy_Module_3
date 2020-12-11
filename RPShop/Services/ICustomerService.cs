using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public interface ICustomerService : IService<Customer>
    {
        int Create(CustomerView model);
        EditCustomer EditCustomer(int id);
    }
}
