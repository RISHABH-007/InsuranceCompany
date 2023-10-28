using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Entity
{
    public class PaymentOfClaims
    {
        [Key]
        public int reportId { get; set; }
        [Range(1, int.MaxValue)]
        public int payment { get; set; }
        public string month { get; set; }
        public int year { get; set; }
    }
}
