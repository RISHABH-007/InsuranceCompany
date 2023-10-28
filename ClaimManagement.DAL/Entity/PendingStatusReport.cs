using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Entity
{
    public class PendingStatusReport
    {
        [Key]
        public int reportId { get; set; }
        public string stage { get; set; }
        [Range(1, int.MaxValue)]
        public int count { get; set; }
        public string month { get; set; }
        public int year { get; set; }
    }
}
