using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Entity
{
    public class SeedingData
    {
        public List<User> GetUsers()
        {
            return new List<User>
        {
            new User { Username = "rishabh_13", Password = "12345" },
        };
        }
    }
}
