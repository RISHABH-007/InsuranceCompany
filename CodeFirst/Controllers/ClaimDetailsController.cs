using ClaimManagement.BLL.Services;
using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using ClaimManagement.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace InsuranceCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimDetailsController : ControllerBase
    {
        private readonly IClaimDetailsService claimDetailsService;

        public ClaimDetailsController(IClaimDetailsService claimDetailsService)
        {
            this.claimDetailsService = claimDetailsService;
        }

        [HttpPost]
        [Route("InsertClaim")]
        public IActionResult InsertClaim([FromBody] ClaimDetails claimDetails)
        {
            claimDetailsService.InsertClaimByService(claimDetails);
            return CreatedAtAction(nameof(InsertClaim), claimDetails);
        }

        [HttpPut]
        [Route("UpdateClaim{id:Guid}")]
        public IActionResult UpdateClaim(string id, [FromBody] ClaimDetails claimDetails)
        {
            claimDetails = claimDetailsService.UpdateClaimByService(id, claimDetails);
            if (claimDetails == null)
            {
                return NotFound();
            }
            return Ok(claimDetails);
        }

        [HttpGet("PendingClaims/{year}/{month}")]
        public ActionResult<IEnumerable<ClaimDetails>> GetPendingClaims(int year, int month)
        {
            var pendingClaims = claimDetailsService.GetPendingClaimsByMonthAndYearByservice(year, month);
            return Ok(pendingClaims);
        }

        [HttpGet("AmountApproved")]
        public IActionResult GetApprovedAmountByMonthAndYear(int year, int month)
        {
            int approvedAmount = claimDetailsService.GetApprovedAmountByMonthAndYearByService(year, month);
            return Ok(approvedAmount);
        }
    }   
}
