using ClaimManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.BLL.Services
{
    public interface IPendingStatusReportService
    {
        public List<ClaimReportDTO_EP7> GetClaimStatusReportsByMonthAndYearByService(string month, int year);
    }
}
