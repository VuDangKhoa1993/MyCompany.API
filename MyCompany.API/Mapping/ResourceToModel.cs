using AutoMapper;
using MyCompany.Core.Models.Entities;
using MyCompany.Core.Services.Communication.Resources;

namespace MyCompany.API.Mapping
{
    public class ResourceToModel : Profile
    {
        public ResourceToModel()
        {
            CreateMap<SaveDepartmentResource, Department>();
            CreateMap<SaveEmployeeResource, Employee>()
                .ForMember(dest => dest.Titles, 
                            opt => opt.MapFrom(src => src.Titles))
                .ForMember(dest => dest.Salaries, 
                           opt => opt.MapFrom(src => src.Salaries));
            CreateMap<SaveTitleResource, Title>();
            CreateMap<SaveSalariesResource, Salaries>();
        }
    }
}
