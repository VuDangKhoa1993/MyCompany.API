using MyCompany.Core.Models.Entities;
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
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> UpdateAsync(int id, Employee employee);
        Task<Employee> DeleteAsync(int id);
    }
}
