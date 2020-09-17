using RPShop.Models;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public class TypeProductRepository : ITypeProductRepository
    {
        private readonly RPDbcontext context;

        public TypeProductRepository(RPDbcontext context)
        {
            this.context = context;
        }
        public int Create(TypeProduct Type)
        {
            context.TypeProducts.Add(Type);
            return context.SaveChanges();
        }
        public TypeProduct Get(int id)
        {
            return context.TypeProducts.FirstOrDefault(e => e.id == id);
        }

        public int Delete(int id)
        {
            var deltype = Get(id);
            if(deltype != null)
            {
                context.TypeProducts.Remove(deltype);
                return context.SaveChanges();
            }
            return -1;
        }

        public int Update(TypeProduct model)
        {
            throw new NotImplementedException();
        }
    }
}
