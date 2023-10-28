using ClaimManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Repository
{
    public interface IPolicyRepository
    {
        public Policy GetPolicyByPolicyNo(string policyNo);
    }
}
