using ClaimManagement.DAL.Models;
using ClaimManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClaimManagement.BLL.Services
{
    public interface IUserAuthenticationService
    {
       public User Authenticate(User  user);
    }
}
