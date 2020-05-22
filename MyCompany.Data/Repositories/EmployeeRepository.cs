using Microsoft.EntityFrameworkCore;
using MyCompany.Core.Models.Entities;
using MyCompany.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MyCompanyDbContext context) : base(context) { }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await _context.Employees.Include(m => m.Titles)
                        .Include(m => m.Salaries).Include(m => m.DepartmentEmployees)
                        .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllWithSalaries()
        {
            return await _context.Employees.Include(m => m.Salaries).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllWithTitle()
        {
            return await _context.Employees.Include(m => m.Titles).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentId(int departmentId)
        {
            var data = await _context.DepartmentEmployees.Where(x => x.DepartmentId == departmentId).Select(x => x.Employees).ToListAsync();
            return data;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.Include(m => m.Titles)
                        .Include(m => m.Salaries).Include(m => m.DepartmentEmployees).FirstOrDefaultAsync(x => x.EmployeeId == id);
        }
    }
}
