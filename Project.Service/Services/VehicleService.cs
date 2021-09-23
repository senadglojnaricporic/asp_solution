using Project.Service.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.Service.Collections;
using System.Collections.Generic;

namespace Project.Service.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly DbContext _DbContext;

        public VehicleService(DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task Create<T>(T entity) where T : class
        {
            await _DbContext.Set<T>().AddAsync(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<T> ReadById<T>(int id) where T : class
        {
            return await _DbContext.Set<T>().FindAsync(id);
        }

        public async Task Update<T>(T entity) where T : class
        {
            _DbContext.Set<T>().Update(entity);
            await _DbContext.SaveChangesAsync();
        }
 
        public async Task Delete<T>(int id) where T : class
        {
            var entity = await _DbContext.Set<T>().FindAsync(id);
            _DbContext.Set<T>().Remove(entity);
            await _DbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetData<T>() where T : class
        {
            var data = from x in _DbContext.Set<T>() select x;
            return data;
        }

        public async Task<IPaginatedList<T>> CreatePageAsync<T>(IQueryable<T> source, int pageIndex, int pageSize) where T : class
        {
            var _source = source;
            var count = await _source.CountAsync();
            var items = await _source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
