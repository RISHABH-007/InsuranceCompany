using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimManagement.DAL.Entity
{
    public class Surveyor
    {
        [Key]
        [Required]
        public int SurveyorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(0, int.MaxValue)]
        public int EstimateLimit { get; set; }
    }
}
