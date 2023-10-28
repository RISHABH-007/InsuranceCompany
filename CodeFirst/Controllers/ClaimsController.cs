using ClaimManagement.BLL.Services;
using ClaimManagement.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ClaimManagement.BLL.Services.MyClaimDetailsService;
using static ClaimManagement.BLL.Services.MyPaymentOfClaimService;
using static ClaimManagement.BLL.Services.MyPendingStatusReportService;

namespace InsuranceCompany.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimDetailsService claimDetailsService;
        private readonly IPendingStatusReportService pendingStatusReportService;
        private readonly IPaymentOfClaimService paymentOfClaimService;
        public ClaimsController(IClaimDetailsService claimDetailsService, IPendingStatusReportService pendingStatusReportService, IPaymentOfClaimService paymentOfClaimService)
        {
            this.claimDetailsService = claimDetailsService;
            this.pendingStatusReportService = pendingStatusReportService;
            this.paymentOfClaimService = paymentOfClaimService;
        }

        //Endpoint 1
        [HttpGet("claims")]
        public IActionResult GetOpenClaims()
        {
            try
            {
                List<ClaimDTO_EP1> openClaims = claimDetailsService.GetOpenClaimsByService();
                return Ok(openClaims);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }

        //Endpoint 2
        [HttpPost("claims/new")]
        public IActionResult AddNewClaim([FromBody] ClaimDTO_EP2 claimDTO)
        {
            try
            {
                string claimId = claimDetailsService.AddNewClaimByService(claimDTO);
                return Ok(new { Status = "Success", ClaimId = claimId });
            }
            catch (InvalidDateException ex)
            {
                return NotFound(ex.Message);
            }
            catch (PolicyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidLossException ex)
            {
                return NotFound(ex.Message);
            }
            catch (MaximumClaimLimitReachedException ex) 
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }

        //Endpoint 4
        [HttpPut("claims/{claimId}/update")]
        public IActionResult UpdateClaim(string claimId, [FromBody] ClaimDTO_EP4 updateClaimDTO)
        {
            try
            {
                claimDetailsService.UpdateTheClaimByService(claimId, updateClaimDTO);
                return Ok(new { Status = "Success" });
            }
            catch (ClaimNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SurveyorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }

        //Endpoints 5
        [HttpPut("surveyorfees/{claimId}")]
        public IActionResult CalculateSurveyorFees(string claimId)
        {
            try
            {
                SurveyorFeesDTO_EP5 feesDTO = claimDetailsService.CalculateSurveyorFeesByService(claimId);
                return Ok(feesDTO);
            }
            catch (ClaimNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SurveyorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SurveyorIsNotEligibleException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }

        //Endpoint 6
        [HttpPut("claims/{claimId}/{claimant}/update")]
        public IActionResult UpdateClaimBySurveyor(string claimId, string claimant, [FromBody] SurveyorUpdateDTO_EP6 surveyorUpdateDTO)
        {
            try
            {
                claimDetailsService.UpdateClaimBySurveyorByService(claimId, claimant, surveyorUpdateDTO);
                return Ok();
            }
            catch (ClaimNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CantApproveException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ClaimOutsideLimitException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SurveyorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ClaimNotOpenException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }

        //Endpoint 7
        [HttpGet("claimStatus/report/{month}/{year}")]
        public IActionResult GetClaimStatusReportsByMonthAndYear(string month, int year)
        {
            try
            {
                List<ClaimReportDTO_EP7> claimReports = pendingStatusReportService.GetClaimStatusReportsByMonthAndYearByService(month, year);
                return Ok(claimReports);
            }
            catch (InvalidMonthException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidYearException ex)
            {
                return NotFound(ex.Message);
            }
            catch (FutureMonException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }

        //Endpoint 8
        [HttpGet("paymentStatus/report/{month}/{year}")]
        public IActionResult GetPaymentStatusReportsByMonthAndYear(string month, int year)
        {
            try
            {
                List<ClaimPaymentReportDTO_EP8> paymentReports = paymentOfClaimService.GetPaymentStatusReportsByMonthAndYearByService(month, year);
                return Ok(paymentReports);
            }
            catch (InvalidMonException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidYrException ex)
            {
                return NotFound(ex.Message);
            }
            catch (FutMonException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }
    }
}
