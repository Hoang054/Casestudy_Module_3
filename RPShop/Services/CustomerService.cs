using Microsoft.CodeAnalysis.CSharp.Syntax;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly RPDbcontext context;

        public CustomerService(RPDbcontext context)
        {
            this.context = context;
        }
        public int Create(CustomerView model)
        {
            var customer = new Customer()
            {
                FullName = model.FullName,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            context.Customers.Add(customer);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var delcustomer = context.Customers.FirstOrDefault(e => e.Id == id);
            if (delcustomer != null)
            {
                context.Customers.Remove(delcustomer);
                return context.SaveChanges();
            }
            return -1;
        }

        public EditCustomer EditCustomer(int id)
        {
            var customer = Get(id);
            var editcustomer = new EditCustomer();
            if(customer != null)
            {
                editcustomer = new EditCustomer()
                {
                    id = customer.Id,
                    Address = customer.Address,
                    Email = customer.Email,
                    FullName = customer.FullName,
                    PhoneNumber = customer.PhoneNumber,
                    totalPrice = customer.totalPrice
                };
            }
            return editcustomer;
        }

        public IEnumerable<Customer> Get()
        {
            throw new NotImplementedException();
        }


        public Customer Get(int id)
        {
           return context.Customers.FirstOrDefault(e => e.Id == id);
           
        }

        public int Update(Customer model)
        {
            var customer = context.Customers.FirstOrDefault(e => e.Id == model.Id);
            if (customer == null)
            {
                return -1;
            }
            customer.FullName = model.FullName;
            customer.Email = model.Email;
            customer.Address = model.Address;
            customer.PhoneNumber = model.Address;
            context.Update(customer);
            return context.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
