using Project.Service.Interfaces;
using Project.Service.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project.Service.Services
{
    public class GenericVehicleService<TEntity> : IGenericVehicleService<TEntity> where TEntity : class
    {
        private readonly VehicleDbContext _DbContext;

        public GenericVehicleService(VehicleDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _DbContext.Set<TEntity>().AddAsync(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> ReadRange(int skipRows, int numberOfItems)
        {
            return await _DbContext.Set<TEntity>().Skip(skipRows).Take(numberOfItems).ToListAsync();
        }

        public async Task<TEntity> ReadById(int id)
        {
            return await _DbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            _DbContext.Set<TEntity>().Update(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _DbContext.Set<TEntity>().FindAsync(id);
            _DbContext.Set<TEntity>().Remove(entity);
            await _DbContext.SaveChangesAsync();
        }
    }
}