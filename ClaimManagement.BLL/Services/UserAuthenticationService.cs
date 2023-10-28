using ClaimManagement.DAL.Models;
using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClaimManagement.BLL.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public UserAuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(User user)
        {
            var seedingData = new SeedingData();
            var predefinedUsers = seedingData.GetUsers();

            // Check if the provided user credentials match predefined users
            var users = predefinedUsers.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            return users;

        }
    }
}
