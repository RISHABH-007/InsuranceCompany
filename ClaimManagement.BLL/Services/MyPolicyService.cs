using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.BLL.Services
{
    public class MyPolicyService: IPolicyService
    {
        public string GeneratePolicyIdByService(string lastName, string vehicleNo)
        {
            string policyId = $"{lastName.Substring(0, 2).ToUpper()}{vehicleNo.Substring(vehicleNo.Length - 3)}{DateTime.Now.Year % 100:00}";
            return policyId;
        }
    }
}
