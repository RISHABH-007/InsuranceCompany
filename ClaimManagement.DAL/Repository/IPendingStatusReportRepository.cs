using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Repository
{
    public interface IPendingStatusReportRepository
    {
        public List<PendingStatusReport> GetClaimStatusReportsByMonthAndYear(string month, int year);
    }
}
