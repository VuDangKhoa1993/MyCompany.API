using Microsoft.EntityFrameworkCore;
using MyCompany.Core.Models.Entities;
using MyCompany.Core.Repositories;
using MyCompany.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyCompanyDbContext context) : base(context) { }

        public async Task<User> Authenticate(string username, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}
