﻿using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly RPDbcontext context;

        public SupplierRepository(RPDbcontext context)
        {
            this.context = context;
        }
        public int CreateSupplier(Supplier model)
        {
            var supplier = new Supplier()
            {
                Email = model.Email,
                Business_code = model.Business_code,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber
            };
            context.Suppliers.Add(supplier);
            return context.SaveChanges();
        }

        public int DeleteSupplier(int id)
        {
            var delType = GetSupplier(id);
            if(delType != null)
            {
                context.Suppliers.Remove(delType);
                return context.SaveChanges();
            }
            return -1;  
        }

        public Supplier GetSupplier(int id)
        {
            return context.Suppliers.FirstOrDefault(e => e.id == id);
        }

        public int UpdateSupplier(UpdateSupplier model)
        {
            var Supplier = GetSupplier(model.id);
            if(Supplier == null){
                return -1;
            }
            Supplier.id = model.id;
            Supplier.Email = model.Email;
            Supplier.Name = model.Name;
            Supplier.PhoneNumber = model.PhoneNumber;
            Supplier.Business_code = model.Business_code;
            context.Update(Supplier);
            return context.SaveChanges();   
        }
    }
}
