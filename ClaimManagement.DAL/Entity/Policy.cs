using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ClaimManagement.DAL.Entity
{ 

    public class Policy
    {
        [Key]
        [StringLength(7)]
        public string PolicyNo { get; set; }
        [MinLength(5)]
        public string InsuredFirstName { get; set; }
        [MinLength(5)]
        public string InsuredLastName { get; set; }
        [CustomDateValidation(ErrorMessage = "DateOfInsurance must not be greater than current date.")]
        public DateTime DateOfInsurance { get; set; }
        public string EmailId { get; set; }
        public string VehicleNo { get; set; }
        public bool Status { get; set; }

        public class CustomDateValidation : ValidationAttribute
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
}

