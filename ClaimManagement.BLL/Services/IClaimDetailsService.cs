using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.BLL.Services
{
    public interface IClaimDetailsService
    {
        public ClaimDetails InsertClaimByService(ClaimDetails claimDetails);
        public ClaimDetails UpdateClaimByService(string claimId, ClaimDetails claimDetails);
        public IEnumerable<ClaimDetails> GetPendingClaimsByMonthAndYearByservice(int year, int month);
        public int GetApprovedAmountByMonthAndYearByService(int year, int month);

        //Endpoints Methods
        public List<ClaimDTO_EP1> GetOpenClaimsByService();
        public string AddNewClaimByService(ClaimDTO_EP2 claimDTO);
        public void UpdateTheClaimByService(string claimId, ClaimDTO_EP4 updateClaimDTO);
        public SurveyorFeesDTO_EP5 CalculateSurveyorFeesByService(string claimId);
        public void UpdateClaimBySurveyorByService(string claimId, string claimant, SurveyorUpdateDTO_EP6 surveyorUpdateDTO);
    }
}
