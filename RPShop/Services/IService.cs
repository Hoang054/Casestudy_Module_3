using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Services
{
    public interface IService<T>
    {
        
        int Delete(int id);
        int Update(T model);
        T Get(int id);

    }
}
