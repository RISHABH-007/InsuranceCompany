using ClaimManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClaimManagement.DAL.Repository
{
    public interface ISurveyorRepository
    {
        public List<Surveyor> GetSurveyors();

        //Endpoints Methods
        public List<Surveyor> GetSurveyorsByEstimateLimit(int estimatedLoss);
        public Surveyor GetSurveyorById(int surveyorId);
    }
}
