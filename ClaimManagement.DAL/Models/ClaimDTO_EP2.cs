using ClaimManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Models
{
    public class ClaimDTO_EP2
    {
        public string PolicyNo { get; set; }
        public int EstimatedLoss { get; set; }
        public DateTime DateOfAccident { get; set; }
    }
}
