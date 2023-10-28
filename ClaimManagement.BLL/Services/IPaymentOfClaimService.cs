using ClaimManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.BLL.Services
{
    public interface IPaymentOfClaimService
    {
        public List<ClaimPaymentReportDTO_EP8> GetPaymentStatusReportsByMonthAndYearByService(string month, int year);
    }
}
