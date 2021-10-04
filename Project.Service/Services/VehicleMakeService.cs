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

        public async Task<IPaginatedList<VehicleMakeDataModel>> GetPageAsync(string sortOrder, string searchString, int pageIndex = 1)
        {
            var _source = from x in _DbContext.Set<VehicleMakeDataModel>() select x;

            if(!string.IsNullOrEmpty(searchString))
            {
                _source = _source.Where(x => x.Name.Contains(searchString));
            }

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

            var list = await PaginatedList<VehicleMakeDataModel>.CreatePageAsync(_source, pageIndex, 3);

            return list;
        }
    }
}
