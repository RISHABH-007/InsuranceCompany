using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.DAL.Repository
{
    public interface IPaymentOfClaimsRepository
    {
       public List<PaymentOfClaims> GetPaymentStatusReportsByMonthAndYear(string month, int year);
    }
}
