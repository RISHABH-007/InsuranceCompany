using ClaimManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Repository
{
    public class MySurveyorRepository : ISurveyorRepository
    {
        private readonly MyDbContext dbContext;
        public MySurveyorRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Surveyor> GetSurveyors()
        {
            return dbContext.Surveyors.ToList();
        }

        //Endpoints
        //EndPoint 3
        public List<Surveyor> GetSurveyorsByEstimateLimit(int estimatedLoss)
        {
            return dbContext.Surveyors.Where(s => s.EstimateLimit >= estimatedLoss).ToList();
        }

        //EndPoint 4 & 5
        public Surveyor GetSurveyorById(int surveyorId)
        {
            return dbContext.Surveyors.FirstOrDefault(s => s.SurveyorId == surveyorId);
        }
    }
}
