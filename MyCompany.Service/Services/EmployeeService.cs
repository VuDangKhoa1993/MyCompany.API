using MyCompany.Core.Models.Entities;
using MyCompany.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        
        public async Task<Employee> CreateAsync(Employee employee)
        {
            return null;
        }

        public Task<Employee> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesByDepartmentIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateAsync(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
