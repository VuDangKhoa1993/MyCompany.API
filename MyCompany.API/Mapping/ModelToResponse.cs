using AutoMapper;
using MyCompany.API.Resources;
using MyCompany.Core.Models.Entities;
using MyCompany.Core.Services.Communication.Resources;

namespace MyCompany.API.Mapping
{
    public class ModelToResponse : Profile
    {
        public ModelToResponse()
        {
            CreateMap<Department, DepartmentResource>();
            CreateMap<Employee, EmployeeResource>();
        }
    }
}
