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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MyCompanyDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Department>> GetAllWithEmployeeId(int employeeId)
        {
            return await _context.DepartmentEmployees.Where(x => x.EmployeeId == employeeId).Select(x => x.Departments).ToListAsync();
        }
    }
}
