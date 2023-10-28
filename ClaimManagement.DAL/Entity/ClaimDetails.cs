using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimManagement.DAL.Entity
{
    public class ClaimDetails
    {
        [Key]
        [StringLength(10)]
        public string ClaimId { get; set; }
        [ForeignKey("Policy")]
        public string PolicyNo { get; set; }
        public Policy Policy { get; set; }
        [Range(0, int.MaxValue)]
        public int EstimatedLoss { get; set; }
        [DateNotGreaterThanCurrent(ErrorMessage = "Date of Accident cannot be greater than current date.")]
        public DateTime DateOfAccident { get; set; }
        public bool ClaimStatus { get; set; }
        [ForeignKey("Surveyor")]
        public int SurveyorId { get; set; }
        public Surveyor Surveyor { get; set; }
        [Range(0, int.MaxValue)]
        public int AmtApprovedBySurveyor { get; set; }
        [DefaultValue(false)]
        public bool InsuranceCompanyApproval { get; set; }
        [DefaultValue(false)]
        public bool WithdrawClaim { get; set; }
        public int SurveyorFees { get; set; }

    }
    public class DateNotGreaterThanCurrentAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date <= DateTime.Now;
            }
            return true; 
        }
    }
}
