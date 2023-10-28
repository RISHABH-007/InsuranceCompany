using ClaimManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public User GetUserByUsername(string Username)
        {
            return _context.User.FirstOrDefault(u => u.Username == Username);
        }
    }
}
