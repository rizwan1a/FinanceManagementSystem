using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.GenericImplementation
{
    public interface IGeneric<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int Id);
        void AddEntity(T entity);
        void RemoveEntity(T entity);
        void UpdateEntity(T entity);
    }
}
