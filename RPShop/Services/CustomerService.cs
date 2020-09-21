using Microsoft.CodeAnalysis.CSharp.Syntax;
using RPShop.Models;
using RPShop.Models.Entities;
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
        public int Create(Customer customer)
        {
            context.Customers.Add(customer);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            //var delcustomer = context.Customers.FirstOrDefault(e => e.id == id);
            //if(delcustomer != null) 
            //{
            //    context.Customers.Remove(delcustomer);
            //    return context.SaveChanges();
            //}
            //return -1;
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        {
            throw new NotImplementedException();
        }

        //public Customer Get(int id)
        //{
        //    return context.Customers.FirstOrDefault(e => e.id == id);
            
        //}

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Customer model)
        {
            //var customer = context.Customers.FirstOrDefault(e => e.id == model.id);
            //if(customer == null)
            //{
            //    return -1;
            //}
            //customer.FullName = model.FullName;
            //customer.Email = model.Email;
            //customer.Address = model.Address;
            //customer.PhoneNumber = model.Address;
            //context.Update(customer);
            //return context.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
