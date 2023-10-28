using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.BLL.Services
{
    public interface ISurveyorService
    {
        public List<Surveyor> GetSurveyorsByService();

        //Endpoints Methods
        public List<SurveyorDTO_EP3> GetAuthorizedSurveyorsByService(int estimatedLoss);
    }
}
