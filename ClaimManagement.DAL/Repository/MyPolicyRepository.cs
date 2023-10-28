using ClaimManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Repository
{
    public class MyPolicyRepository : IPolicyRepository
    {
        private readonly MyDbContext dbContext;
        public MyPolicyRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Policy GetPolicyByPolicyNo(string policyNo)
        {
            return dbContext.Policies.FirstOrDefault(p => p.PolicyNo == policyNo);
        }
    }
}
