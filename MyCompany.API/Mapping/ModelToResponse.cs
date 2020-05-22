using AutoMapper;
using MyCompany.API.Resources;
using MyCompany.Core.Models.Entities;
using MyCompany.Core.Services.Communication.Resources;
using System.Linq;

namespace MyCompany.API.Mapping
{
    public class ModelToResponse : Profile
    {
        public ModelToResponse()
        {
            CreateMap<Department, DepartmentResource>();
            CreateMap<Employee, EmployeeResource>()
                .ForMember(
                        dest => dest.DepartmentId,
                        opt => opt.MapFrom(src => src.DepartmentEmployees
                          .Where(x => x.EmployeeId == src.EmployeeId).Select(x => x.DepartmentId)))
                .ForMember(dest => dest.Titles,
                            opt => opt.MapFrom(src => src.Titles.Select(x => x.Titles)))
                .ForMember(dest => dest.Salaries,
                            opt => opt.MapFrom(src => src.Salaries.Select(x => x.Salary)));
        }
    }
}
