using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public interface IRepository<T>
    {
        int Create(T t);
        int Delete(int id);
        int Update(T model);
        T Get(int id);
    }
}
