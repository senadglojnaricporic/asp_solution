using Project.Service.Interfaces;
using Project.Service.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Project.Service.Collections;

namespace Project.Service.Services
{
    public class VehicleMakeService : VehicleService, IVehicleMakeService
    {
        private readonly DbContext _DbContext;

        public VehicleMakeService(DbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<IPaginatedList<VehicleMakeDataModel>> Sort(IPaginatedList<VehicleMakeDataModel> source, string sortOrder)
        {
            var _source = source.AsQueryable();

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

            source = (PaginatedList<VehicleMakeDataModel>) await _source.ToListAsync();

            return source;
        }

    }
}
