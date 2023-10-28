using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Repository
{
    public class MyPendingStatusReportRepository: IPendingStatusReportRepository
    {
        private readonly MyDbContext dbContext;
        public MyPendingStatusReportRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<PendingStatusReport> GetClaimStatusReportsByMonthAndYear(string month, int year)
        {
            return dbContext.PendingStatusReport
             .Where(r => r.month == month && r.year == year)
             .ToList();
        }
    }
}
