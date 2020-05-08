using AutoMapper;
using MyCompany.API.Resources;
using MyCompany.Core.Models.Entities;

namespace MyCompany.API.Mapping
{
    public class ModelToResponse : Profile
    {
        public ModelToResponse()
        {
            CreateMap<Department, DepartmentResource>();
        }
    }
}
