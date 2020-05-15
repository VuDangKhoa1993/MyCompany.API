using MyCompany.Core.Models.Entities;
using MyCompany.Core.Services.Communication.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<Employee>> GetAllEmployeesByDepartmentIdAsync(int departmentId);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<EmployeeResponse> CreateAsync(Employee employee);
        Task<EmployeeResponse> UpdateAsync(int id, Employee employee);
        Task<EmployeeResponse> DeleteAsync(int id);
    }
}
