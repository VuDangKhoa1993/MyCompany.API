using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllWithSalaries();
        Task<IEnumerable<Employee>> GetAllWithTitle();
        Task<IEnumerable<Employee>> GetEmployeeByDepartmentId(int departmentId);
    }
}
