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

        public IQueryable<VehicleMake> Sort(IQueryable<VehicleMake> source, string sortOrder)
        {
            var _source = source;

            switch(sortOrder)
            {
                case "name" :
                    _source = _source.OrderBy(x => x.Name);
                    break;
                case "name_desc" :
                    _source = _source.OrderByDescending(x => x.Name);
                    break;
                case "abrv" :
                    _source = _source.OrderBy(x => x.Abrv);
                    break;
                case "abrv_desc" :
                    _source = _source.OrderByDescending(x => x.Abrv);
                    break;
                default :
                    _source = _source.OrderBy(x => x.Id);
                    break;
            }

            return _source;
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

        public IQueryable<VehicleModel> Sort(IQueryable<VehicleModel> source, string sortOrder)
        {
            var _source = source;

            switch(sortOrder)
            {
                case "name" :
                    _source = _source.Include(x => x.VehicleMake).OrderBy(x => x.Name);
                    break;
                case "name_desc" :
                    _source = _source.Include(x => x.VehicleMake).OrderByDescending(x => x.Name);
                    break;
                case "abrv" :
                    _source = _source.Include(x => x.VehicleMake).OrderBy(x => x.Abrv);
                    break;
                case "abrv_desc" :
                    _source = _source.Include(x => x.VehicleMake).OrderByDescending(x => x.Abrv);
                    break;
                case "make" :
                    _source = _source.Include(x => x.VehicleMake).OrderBy(x => x.VehicleMake.Name);
                    break;
                case "make_desc" :
                    _source = _source.Include(x => x.VehicleMake).OrderByDescending(x => x.VehicleMake.Name);
                    break;
                default :
                    _source = _source.Include(x => x.VehicleMake).OrderBy(x => x.Id);
                    break;
            }

            return _source;
        }

        public IQueryable<VehicleModel> FilterModelByMake(IQueryable<VehicleModel> source, string searchString)
        {
            var _source = source;

            if(string.IsNullOrEmpty(searchString))
            {
                _source = _source.Where(x => x.VehicleMake.Name.Contains(searchString));
            }

            return _source;
        }
    }
}