using Project.Service.Interfaces;
using Project.Service.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Project.Service.Collections;
using System.Collections.Generic;

namespace Project.Service.Services
{
    public class VehicleModelService : VehicleService, IVehicleModelService
    {
        private readonly DbContext _DbContext;

        public VehicleModelService(DbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }

        public IQueryable<VehicleModelDataModel> Sort(IQueryable<VehicleModelDataModel> source, string sortOrder)
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

        public IQueryable<VehicleModelDataModel> FilterModelByMake(IQueryable<VehicleModelDataModel> source, string searchString)
        {
            var _source = source;

            if(!string.IsNullOrEmpty(searchString))
            {
                _source = _source.Where(x => x.VehicleMake.Name.Contains(searchString));
            }

            return _source;
        }
    }
}
