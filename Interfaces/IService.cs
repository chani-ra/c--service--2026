using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Service.Interfaces
{
    internal interface IService<T>
    {
        List<T> GetAll();
        T Get(int id);
        T AddItem(T item);
        void UpdateItem(int id, T item);
        void DeleteItem(int id);
    }
}