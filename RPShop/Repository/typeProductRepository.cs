using RPShop.Models;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public class typeProductRepository : ItypeProductRepository
    {
        private readonly RPDbcontext context;

        public typeProductRepository(RPDbcontext context)
        {
            this.context = context;
        }
        public int CreateType(typeProduct type)
        {
            context.typeProducts.Add(type);
            return context.SaveChanges();
        }
        public typeProduct GetTypeProduct(int id)
        {
            return context.typeProducts.FirstOrDefault(e => e.id == id);
        }

        public int DeleteType(int id)
        {
            var deltype = GetTypeProduct(id);
            if(deltype != null)
            {
                context.typeProducts.Remove(deltype);
                return context.SaveChanges();
            }
            return -1;
        }

        public int UpdateType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
