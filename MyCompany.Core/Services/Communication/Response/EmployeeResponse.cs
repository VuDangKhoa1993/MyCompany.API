using MyCompany.API.Communication;
using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Core.Services.Communication.Response
{
    public class EmployeeResponse : BaseResponse<Employee>
    {
        public EmployeeResponse(Employee employee) : base(employee) { }

        public EmployeeResponse(string message) : base(message) { }
    }
}
