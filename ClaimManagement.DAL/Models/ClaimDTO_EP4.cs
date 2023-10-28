using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Models
{
    public class ClaimDTO_EP4
    {
        public bool? ClaimStatus { get; set; }
        //public int? AmtApprovedBySurveyor { get; set; }
        public bool? InsuranceCompanyApproval { get; set; }
        public bool? WithdrawClaim { get; set; }
        public int? SurveyorId { get; set; }
    }
}
