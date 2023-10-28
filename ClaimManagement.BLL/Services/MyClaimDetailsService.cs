using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using ClaimManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.BLL.Services
{
    public class MyClaimDetailsService: IClaimDetailsService 
    {
        private readonly IClaimDetailsRepository claimDetailsRepository;
        private readonly ISurveyorRepository surveyorRepository;
        private readonly IPolicyRepository policyRepository;
        public MyClaimDetailsService(IClaimDetailsRepository claimDetailsRepository, ISurveyorRepository surveyorRepository, IPolicyRepository policyRepository)
        {
            this.claimDetailsRepository = claimDetailsRepository;
            this.surveyorRepository = surveyorRepository;
            this.policyRepository = policyRepository;
        }

        public ClaimDetails InsertClaimByService(ClaimDetails claimDetails)
        {
            return claimDetailsRepository.InsertClaim(claimDetails);
        }

        public ClaimDetails UpdateClaimByService(string claimId, ClaimDetails claimDetails)
        {
            return claimDetailsRepository.UpdateClaim(claimId, claimDetails);
        }

        public IEnumerable<ClaimDetails> GetPendingClaimsByMonthAndYearByservice(int year, int month)
        {
            return claimDetailsRepository.GetPendingClaimsByMonthAndYear(year, month);
        }

        public int GetApprovedAmountByMonthAndYearByService(int year, int month)
        {
            return claimDetailsRepository.GetApprovedAmountByMonthAndYear(year, month);
        }

        //Endpoints Methods
        //Endpoint 1
        public List<ClaimDTO_EP1> GetOpenClaimsByService()
        {
            List<ClaimDetails> openClaims = claimDetailsRepository.GetOpenClaims();

            List<ClaimDTO_EP1> claimDTOs = openClaims.Select(claim => new ClaimDTO_EP1
            {
                ClaimId = claim.ClaimId,
                PolicyNo = claim.PolicyNo,
                EstimatedLoss = claim.EstimatedLoss,
                DateOfAccident = claim.DateOfAccident,
                ClaimStatus = claim.ClaimStatus,
                SurveyorId = claim.SurveyorId,
                AmtApprovedBySurveyor = claim.AmtApprovedBySurveyor,
                InsuranceCompanyApproval = claim.InsuranceCompanyApproval,
                WithdrawClaim = claim.WithdrawClaim,
                SurveyorFees = claim.SurveyorFees
            }).ToList();

            return claimDTOs;

        }

        //EndPoint 2
        public string AddNewClaimByService(ClaimDTO_EP2 claimDTO)
        {
            Policy policy = policyRepository.GetPolicyByPolicyNo(claimDTO.PolicyNo);

            //Business Rule 3: Cannot raise a claim request if policyNo is not valid or does not exist.
            if (policy == null)
            {
                throw new PolicyNotFoundException("PolicyNo is not valid or does not exist.");
            }

            if(claimDTO.EstimatedLoss<=0)
            {
                throw new InvalidLossException("Loss can't be negative or zero");
            }

            if (claimDTO.DateOfAccident > DateTime.Now)
            {
                throw new InvalidDateException("Accident Year Can't be in Future");
            }

            //Business Rule 4: Throws Exception if raise more than one claim in a year
            int existingClaimCount = claimDetailsRepository.GetClaimCountForPolicyAndYear(policy.PolicyNo, claimDTO.DateOfAccident.Year);
            if (existingClaimCount >= 1)
            {
                throw new MaximumClaimLimitReachedException("Maximum claim limit reached for the year.");
            }

            string claimId = GenerateClaimId(policy.PolicyNo, claimDTO.DateOfAccident.Year);

            ClaimDetails claims = new ClaimDetails
            {
                ClaimId = claimId,
                PolicyNo = claimDTO.PolicyNo,
                EstimatedLoss = claimDTO.EstimatedLoss,
                DateOfAccident = claimDTO.DateOfAccident,
                ClaimStatus = false,
                SurveyorId = 10,
                AmtApprovedBySurveyor= 0,
                InsuranceCompanyApproval = false,
                WithdrawClaim = false,
                SurveyorFees = 0,
            };
           
            claimDetailsRepository.AddNewClaim(claims);
            
            return claimId;

            
        }
        //Business Rule 2: Method to ClaimId
        private string GenerateClaimId(string policyNo, int accidentYear)
        {

            //string year = DateTime.Now.Year.ToString("D4");
            string year= accidentYear.ToString("D4");
            string claimId = $"CL{policyNo.Substring(policyNo.Length - 4)}{year}";

            return claimId;
        }
        //Exceptions for Endpoint 2

        public class PolicyNotFoundException : Exception
        {
            public PolicyNotFoundException(string message) : base(message) { }
        }
        public class InvalidDateException : Exception
        {
            public InvalidDateException(string message) : base(message){ }
        }
        public class InvalidLossException : Exception
        {
            public InvalidLossException(string message) : base(message) { }
        }
        public class MaximumClaimLimitReachedException : Exception
        {
            public MaximumClaimLimitReachedException(string message) : base(message) { }
        }

        //EndPoint 4 
        public void UpdateTheClaimByService(string claimId, ClaimDTO_EP4 updateClaimDTO)
        {
            ClaimDetails existingClaim = claimDetailsRepository.GetClaimById(claimId);
            if (existingClaim == null)
            {
                throw new ClaimNotFoundException("Claim not found.");
            }
            if (updateClaimDTO.ClaimStatus.HasValue)
            {
                existingClaim.ClaimStatus = updateClaimDTO.ClaimStatus.Value;
            }
            if (updateClaimDTO.InsuranceCompanyApproval.HasValue)
            {
                existingClaim.InsuranceCompanyApproval = updateClaimDTO.InsuranceCompanyApproval.Value;
            }
            if (updateClaimDTO.WithdrawClaim.HasValue)
            {
                existingClaim.WithdrawClaim = updateClaimDTO.WithdrawClaim.Value;
            }
            if (updateClaimDTO.SurveyorId.HasValue)
            {
                Surveyor surveyor = surveyorRepository.GetSurveyorById(updateClaimDTO.SurveyorId.Value);
                if (surveyor == null)
                {
                    throw new SurveyorNotFoundException("Surveyor not found.");
                }

                existingClaim.SurveyorId = surveyor.SurveyorId;
            }
            claimDetailsRepository.UpdateTheClaim(existingClaim);
        }
        //Exceptions for Endpoint 4
        public class ClaimNotFoundException : Exception
        {
            public ClaimNotFoundException(string message) : base(message) { }
        }
        public class SurveyorNotFoundException : Exception
        {
            public SurveyorNotFoundException(string message) : base(message) { }
        }

        //Endpoint 5
        public SurveyorFeesDTO_EP5 CalculateSurveyorFeesByService(string claimId)
        {
            ClaimDetails existingClaim = claimDetailsRepository.GetClaimById(claimId);
            if (existingClaim == null)
            {
                throw new ClaimNotFoundException("Claim not found.");
            }

            if (!existingClaim.ClaimStatus || !existingClaim.InsuranceCompanyApproval)
            {
                throw new InvalidOperationException("Claim is not eligible for releasing fees.");
            }
  
            Surveyor surveyor = surveyorRepository.GetSurveyorById(existingClaim.SurveyorId);
            if (surveyor == null)
            {
                throw new SurveyorNotFoundException("Surveyor not found.");
            }

            //Business Rule 5
            if (existingClaim.EstimatedLoss > surveyor.EstimateLimit)
            {
                throw new SurveyorIsNotEligibleException("Surveyor is Not Eligible to Calculate the Claim...Hence No Fees Released");
            }

            //Business Rule 6: Update the SurveyorFees after Calculation 
            int fees = claimDetailsRepository.GetFeesByEstimatedLoss(existingClaim.EstimatedLoss);
 
            existingClaim.SurveyorFees = fees;
            claimDetailsRepository.UpdateTheClaim(existingClaim);

            SurveyorFeesDTO_EP5 feesDTO = new SurveyorFeesDTO_EP5
            {
                SurveyorFees = fees
            };

            return feesDTO;
        }
        //Exception For Endpoint 5
        public class SurveyorIsNotEligibleException : Exception
        {
            public SurveyorIsNotEligibleException(string message) : base(message) { }
        }

        //Endpoint 6
        public void UpdateClaimBySurveyorByService(string claimId, string claimant, SurveyorUpdateDTO_EP6 surveyorUpdateDTO)
        {
            ClaimDetails existingClaim = claimDetailsRepository.GetClaimByIdAndClaimant(claimId, claimant);
            if (existingClaim == null)
            {
                throw new ClaimNotFoundException("Claim not found.");
            }

            if (!existingClaim.ClaimStatus)
            {
                throw new ClaimNotOpenException("Claim is not open.");
            }
            Surveyor surveyor = surveyorRepository.GetSurveyorById(existingClaim.SurveyorId);
            if (surveyor == null)
            {
                throw new SurveyorNotFoundException("Surveyor not found.");
            }

            // Business Rule 5: Check if estimated loss is within the surveyor's estimate limit
            if (existingClaim.EstimatedLoss > surveyor.EstimateLimit)
            {
                throw new ClaimOutsideLimitException("Claim Estimated loss is outside Surveyor's Limit.");
            }

            if(surveyorUpdateDTO.ApprovedClaimAmount> existingClaim.EstimatedLoss)
            {
                throw new CantApproveException("Surveyor Cant Approve Claim More than Estimated Loss");
            }

            // Update and save claimDetails properties
            existingClaim.AmtApprovedBySurveyor = surveyorUpdateDTO.ApprovedClaimAmount;

            claimDetailsRepository.UpdateTheClaim(existingClaim);
        }
        //Exception for Endpoint 6
        public class ClaimOutsideLimitException : Exception
        {
            public ClaimOutsideLimitException(string message) : base(message) { }
        }
        public class CantApproveException : Exception
        {
            public CantApproveException(string message) : base(message) { }
        }
        public class ClaimNotOpenException : Exception
        {
            public ClaimNotOpenException(string message) : base(message) { }
        }
    }
}
