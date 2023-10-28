using System.ComponentModel.DataAnnotations;

namespace ClaimManagement.DAL.Entity
{
    public class Fees
    {
        [Key]
        public int FeeId { get; set; }
        public int EstimateStartLimit { get; set; }
        [Compare(nameof(EstimateStartLimit), ErrorMessage = "EstimateStartLimit should be less than EstimateEndLimit")]
        public int EstimateEndLimit { get; set; }
        public int fees { get; set; }

    }
}