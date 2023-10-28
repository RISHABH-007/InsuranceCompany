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
    public class MyClaimDetailsRepository : IClaimDetailsRepository
    {
        private readonly MyDbContext dbContext;
        public MyClaimDetailsRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ClaimDetails InsertClaim(ClaimDetails claimDetails)
        {
            dbContext.ClaimDetails.Add(claimDetails);
            dbContext.SaveChanges();
            return claimDetails;
        }

        public ClaimDetails UpdateClaim(string claimId, ClaimDetails claimDetails)
        {
            var isExists=dbContext.ClaimDetails.FirstOrDefault(x => x.ClaimId == claimId);
            if (isExists == null) 
            {
                return null;
            }
            dbContext.SaveChanges ();
            return claimDetails;
        }

        public IEnumerable<ClaimDetails> GetPendingClaimsByMonthAndYear(int year, int month)
        {
           return dbContext.ClaimDetails
                .Where(c => c.DateOfAccident.Year == year && c.DateOfAccident.Month == month && !c.ClaimStatus)
                .ToList();
        }

        public int GetApprovedAmountByMonthAndYear(int year, int month)
        {
            return dbContext.ClaimDetails
                .Where(c => c.InsuranceCompanyApproval && c.DateOfAccident.Year == year && c.DateOfAccident.Month == month)
                .Sum(c => c.AmtApprovedBySurveyor);
        }

        //Endpoints Methods
        //Endpoint 1
        public List<ClaimDetails> GetOpenClaims()
        {
            return dbContext.ClaimDetails.Where(c => c.ClaimStatus).ToList();
        }

        //Endpoint 2
        public void AddNewClaim(ClaimDetails claimdetails)
        {
            dbContext.ClaimDetails.Add(claimdetails);
            dbContext.SaveChanges();
        }
        public int GetClaimCountForPolicyAndYear(string policyNo, int year)
        {
            return dbContext.ClaimDetails.Count(c => c.PolicyNo == policyNo && c.DateOfAccident.Year == year);
        }

        //Endpoint 4 & 5
        public ClaimDetails GetClaimById(string claimId) //Used By Endpoint 4 & 5
        {
            return dbContext.ClaimDetails.FirstOrDefault(c => c.ClaimId == claimId);
        }
        public void UpdateTheClaim(ClaimDetails claimdetails)
        {
            dbContext.ClaimDetails.Update(claimdetails);
            dbContext.SaveChanges();
        }

        //Endpoint 5
        public int GetFeesByEstimatedLoss(int EstimatedLoss)
        {
            int fees;

            if (EstimatedLoss >= 5000 && EstimatedLoss < 10000)
            {
                fees = 1000;
            }
            else if (EstimatedLoss >= 10000 && EstimatedLoss < 20000)
            {
                fees = 2000;
            }
            else if (EstimatedLoss >= 20000 && EstimatedLoss < 70000)
            {
                fees = 7000;
            }
            else
            {
                fees = 0;
            }

            return fees;
        }

        //Endpoint 6
        public ClaimDetails GetClaimByIdAndClaimant(string claimId, string claimant)
        {
            return dbContext.ClaimDetails.FirstOrDefault(c => c.ClaimId == claimId && c.PolicyNo == claimant);
        }
        
    }
    
}
