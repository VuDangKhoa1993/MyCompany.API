using MyCompany.API.Response;
using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Core.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<IEnumerable<Department>> GetAllDepartmentsByEmployeeIdAsync(int employeeId);
        Task<Department> GetDepartmentById(int id);
        Task<DepartmentResponse> CreateAsync(Department department);
        Task<DepartmentResponse> UpdateAsync(int id, Department department);
        Task<DepartmentResponse> DeleteAsync(int id);
    }
}
