using Project.Service.Data;
using Project.Service.Interfaces;
using Project.Service.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.Service.Collections;

namespace Project.Service.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleDbContext _DbContext;

        public VehicleService(VehicleDbContext DbContext)
        {
            _DbContext = DbContext;//-----------ninject
        }

        public async Task Create(VehicleMake entity)
        {
            await _DbContext.VehicleMakes.AddAsync(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<VehicleMake> ReadMakeById(int id)
        {
            return await _DbContext.VehicleMakes.FindAsync(id);
        }

        public async Task Update(VehicleMake entity)
        {
            _DbContext.VehicleMakes.Update(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task DeleteMake(int id)
        {
            var entity = await _DbContext.VehicleMakes.FindAsync(id);
            _DbContext.VehicleMakes.Remove(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<PaginatedList<VehicleMake>> CreatePageAsync(IQueryable<VehicleMake> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<VehicleMake>(items, count, pageIndex, pageSize);
        }

        public async Task Create(VehicleModel entity)
        {
            await _DbContext.VehicleModels.AddAsync(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<VehicleModel> ReadModelById(int id)
        {
            return await _DbContext.VehicleModels.FindAsync(id);
        }

        public async Task Update(VehicleModel entity)
        {
            _DbContext.VehicleModels.Update(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task DeleteModel(int id)
        {
            var entity = await _DbContext.VehicleModels.FindAsync(id);
            _DbContext.VehicleModels.Remove(entity);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<PaginatedList<VehicleModel>> CreatePageAsync(IQueryable<VehicleModel> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<VehicleModel>(items, count, pageIndex, pageSize);
        }
    }
}