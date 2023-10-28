using ClaimManagement.BLL.Services;
using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using ClaimManagement.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyorController : ControllerBase
    {
        private readonly ISurveyorService surveyorService;
        
        public SurveyorController(ISurveyorService surveyorService)
        {
            this.surveyorService = surveyorService;
        }
        [HttpGet("GetSurveyor")]
        public IActionResult GetSurveyorsList()
        {
            var surveyors =surveyorService.GetSurveyorsByService();
            return Ok(surveyors);
        }

        //EndPoints Controllers
        //Endpoint 3
        [HttpGet("{estimatedLoss}")]
        public IActionResult GetAuthorizedSurveyors(int estimatedLoss)
        {
            try
            {
                List<SurveyorDTO_EP3> authorizedSurveyors = surveyorService.GetAuthorizedSurveyorsByService(estimatedLoss);
                return Ok(authorizedSurveyors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }
    }
}
