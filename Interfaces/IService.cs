using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Service.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> AddItem(T item);
        Task<bool> UpdateItem(int id, T item);
        Task<bool> DeleteItem(int id);
    }
}