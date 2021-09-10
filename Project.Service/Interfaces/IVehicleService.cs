/*popis funkcija

--make :  sort by id, sort by name, sort by abrv, filter by name, filter by abrv

--model :  sort by id, sort by make, sort by name, sort by abrv, filter by make, filter by name, filter by abrv
*/

using Project.Service.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Project.Service.Interfaces
{
    public interface IVehicleService : IGenericVehicleService<VehicleMake>, IGenericVehicleService<VehicleModel>
    {
        Task DeleteMake(int id);
        Task DeleteModel(int id);
        Task<VehicleMake> ReadMakeById(int id);
        Task<VehicleModel> ReadModelById(int id);
        IQueryable<VehicleModel> FilterModelByMake(IQueryable<VehicleModel> source, string searchString);

    }
}