using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Repository
{
    public interface IClaimDetailsRepository
    {
        public ClaimDetails InsertClaim(ClaimDetails claimDetails);
        public ClaimDetails UpdateClaim(string claimId, ClaimDetails claimDetails);
        public IEnumerable<ClaimDetails>GetPendingClaimsByMonthAndYear(int year, int month);
        public int GetApprovedAmountByMonthAndYear(int year, int month);

        //Endpoints Methods
        public List<ClaimDetails> GetOpenClaims();
        public void AddNewClaim(ClaimDetails claimdetails);
        public int GetClaimCountForPolicyAndYear(string policyNo, int year);
        ClaimDetails GetClaimById(string claimId);
        public void UpdateTheClaim(ClaimDetails claimdetails);
        public int GetFeesByEstimatedLoss(int estimatedLoss);
        public ClaimDetails GetClaimByIdAndClaimant(string claimId, string claimant);

    }
}
