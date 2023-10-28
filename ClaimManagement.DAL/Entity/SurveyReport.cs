using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Entity
{
    public class SurveyReport
    {

        [Key]
        public string ClaimId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "PolicyNo cannot be negative.")]
        public string PolicyNo { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "LabourCharge cannot be negative.")]
        public int LabourCharges { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "PartsCost cannot be negative.")]
        public int PartsCost { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "PolicyClass cannot be negative.")]
        public int PolicyClass { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "DepreciationCost cannot be negative.")]
        public int DepreciationCost { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "TotalAmount cannot be negative.")]
        public int TotalAmount { get; set; }
    }
}
