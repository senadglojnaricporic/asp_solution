using AutoMapper;
using Project.Service.Models;
using Project.MVC.Models;
using Project.Service.Collections;

namespace Project.MVC.Maps
{
    public class VehicleModelProfile : Profile
    {
        public VehicleModelProfile()
        {
            CreateMap<VehicleModelDataModel, VehicleModelViewModel>();
            CreateMap<PaginatedList<VehicleModelDataModel>, PaginatedList<VehicleModelViewModel>>()
                .ForCtorParam("items", opt => opt.MapFrom(src => src.Items))
                .ForCtorParam("count", opt => opt.MapFrom(src => src.ItemsCount))
                .ForCtorParam("pageIndex", opt => opt.MapFrom(src => src.PageIndex))
                .ForCtorParam("pageSize", opt => opt.MapFrom(src => src.PageSize));
        }
    }
}
