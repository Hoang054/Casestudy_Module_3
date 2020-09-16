using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Repository
{
    public interface ItypeProductRepository
    {
        int CreateType(typeProduct type);
        int DeleteType(int id);
        int UpdateType(int id);
    }
}
