using D2Soft.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Application.Business.GenericImplementation
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<T> FindById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public void RemoveEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
