using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Authenticate(string username, string password);
    }
}
