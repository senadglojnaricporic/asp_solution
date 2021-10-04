using Project.Service.Interfaces;
using Project.Service.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Project.Service.Collections;

namespace Project.Service.Services
{
    public class VehicleModelService : VehicleService, IVehicleModelService
    {
        private readonly DbContext _DbContext;

        public VehicleModelService(DbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<IPaginatedList<VehicleModelDataModel>> GetPageAsync(string sortOrder, string searchString, int pageIndex = 1)
        {
            var _source = from x in _DbContext.Set<VehicleModelDataModel>() select x;

            if(!string.IsNullOrEmpty(searchString))
            {
                _source = _source.Where(x => x.VehicleMake.Name.Contains(searchString));
            }

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

            var list = await PaginatedList<VehicleModelDataModel>.CreatePageAsync(_source, pageIndex, 3);

            return list;
        }
    }
}
