using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using ClaimManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.BLL.Services
{
    public class MySurveyorService : ISurveyorService
    {
        private readonly ISurveyorRepository surveyorRepository;

        public MySurveyorService(ISurveyorRepository surveyorRepository)
        {
            this.surveyorRepository = surveyorRepository;   
        }
        public List<Surveyor> GetSurveyorsByService()
        {
            return surveyorRepository.GetSurveyors();
        }

        //Endpoints Methods
        //EndPoint 3
        public List<SurveyorDTO_EP3> GetAuthorizedSurveyorsByService(int estimatedLoss)
        {
            //Business Rule 5: Estimate loss must be in the estimated limit from Surveyor table. 
            List <Surveyor> authorizedSurveyors = surveyorRepository.GetSurveyorsByEstimateLimit(estimatedLoss);

            List<SurveyorDTO_EP3> surveyorDTOs = authorizedSurveyors.Select(surveyor => new SurveyorDTO_EP3
            {
                SurveyorId = surveyor.SurveyorId,
                FirstName = surveyor.FirstName,
                LastName = surveyor.LastName,
                EstimateLimit = surveyor.EstimateLimit
            }).ToList();

            return surveyorDTOs;
        }
    }
}
