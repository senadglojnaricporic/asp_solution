using Project.Service.Interfaces;
using Project.Service.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Project.Service.Collections;
using System.Collections.Generic;

namespace Project.Service.Services
{
    public class VehicleMakeService : VehicleService, IVehicleMakeService
    {
        private readonly DbContext _DbContext;

        public VehicleMakeService(DbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }

        public IQueryable<VehicleMakeDataModel> Sort(IQueryable<VehicleMakeDataModel> source, string sortOrder)
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

            return  _source;
        }

    }
}
