using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
        IUserRepository User { get; }
        Task<int> CompleteAsync();
    }
}
