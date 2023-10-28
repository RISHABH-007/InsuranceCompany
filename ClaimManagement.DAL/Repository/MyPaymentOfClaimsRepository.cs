using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Repository
{
    public class MyPaymentOfClaimsRepository: IPaymentOfClaimsRepository
    {
        private readonly MyDbContext dbContext;
        public MyPaymentOfClaimsRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<PaymentOfClaims> GetPaymentStatusReportsByMonthAndYear(string month, int year)
        {
            return dbContext.PaymentOfClaims
            .Where(r => r.month == month && r.year == year)
            .ToList();
        }
    }
}
