using Project.Service.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
    }
}
