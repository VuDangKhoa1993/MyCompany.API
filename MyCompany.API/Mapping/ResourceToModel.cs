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
        }
    }
}
