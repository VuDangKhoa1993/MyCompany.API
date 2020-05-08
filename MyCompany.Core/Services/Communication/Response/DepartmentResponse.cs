using MyCompany.API.Communication;
using MyCompany.Core.Models.Entities;

namespace MyCompany.API.Response
{
    public class DepartmentResponse : BaseResponse<Department>
    {
        public DepartmentResponse(Department department) : base(department) { }

        public DepartmentResponse(string message) : base(message) { }
    }
}
