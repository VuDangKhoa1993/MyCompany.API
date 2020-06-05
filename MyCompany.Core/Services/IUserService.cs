using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Core.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
