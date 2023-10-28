using ClaimManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Models
{
    public class ClaimDTO_EP1
    {
        public string ClaimId { get; set; }
        public string PolicyNo { get; set; }
        public int EstimatedLoss { get; set; }
        public DateTime DateOfAccident { get; set; }
        public bool ClaimStatus { get; set; }
        public int SurveyorId { get; set; }
        public int AmtApprovedBySurveyor { get; set; }
        public bool InsuranceCompanyApproval { get; set; }
        public bool WithdrawClaim { get; set; }
        public int SurveyorFees { get; set; }
    }
}
