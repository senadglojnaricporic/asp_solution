using AutoMapper;
using Project.Service.Models;
using Project.MVC.Models;
using Project.Service.Collections;

namespace Project.MVC.Maps
{
    public class VehicleMakeProfile : Profile
    {
        public VehicleMakeProfile()
        {
            CreateMap<VehicleMakeDataModel, VehicleMakeViewModel>().ReverseMap();
            CreateMap<PaginatedList<VehicleMakeDataModel>, PaginatedList<VehicleMakeViewModel>>()
                .ForCtorParam("items", opt => opt.MapFrom(src => src.Items))
                .ForCtorParam("count", opt => opt.MapFrom(src => src.ItemsCount))
                .ForCtorParam("pageIndex", opt => opt.MapFrom(src => src.PageIndex))
                .ForCtorParam("pageSize", opt => opt.MapFrom(src => src.PageSize));
        }
    }
}
