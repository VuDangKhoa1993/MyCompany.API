using MyCompany.Core.Repositories;
using MyCompany.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyCompanyDbContext _context;
        private IDepartmentRepository departmentRepository;
        private IEmployeeRepository employeeRepository;
        private IUserRepository userRepository;

        public UnitOfWork(MyCompanyDbContext context)
        {
            _context = context;
        }

        public IDepartmentRepository Department => departmentRepository = departmentRepository ?? new DepartmentRepository(_context);
        public IEmployeeRepository Employee => employeeRepository = employeeRepository ?? new EmployeeRepository(_context);
        public IUserRepository User => userRepository = userRepository ?? new UserRepository(_context);
        public async Task<int> CompleteAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
