using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using ClaimManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManagement.BLL.Services
{
    //Endpoint 7
    public class MyPendingStatusReportService: IPendingStatusReportService
    {
        private readonly IPendingStatusReportRepository pendingStatusReportRepository;
        public MyPendingStatusReportService(IPendingStatusReportRepository pendingStatusReportRepository)
        {
            this.pendingStatusReportRepository = pendingStatusReportRepository;
        }
        public List<ClaimReportDTO_EP7> GetClaimStatusReportsByMonthAndYearByService(string month, int year)
        {
            if (!IsValidMonth(month))
            {
                throw new InvalidMonthException("Invalid month.");
            }

            if (!IsValidYear(year))
            {
                throw new InvalidYearException("You Cannot enter future Year.");
            }

            if(year==DateTime.Now.Year && !IsFutureMonth(month))
            {
                throw new FutureMonException("Future Month");
            }

            List<PendingStatusReport> reportEntities = pendingStatusReportRepository.GetClaimStatusReportsByMonthAndYear(month, year);
            List<ClaimReportDTO_EP7> claimReports = reportEntities.Select(entity => new ClaimReportDTO_EP7
            {
                reportId = entity.reportId,
                stage = entity.stage,
                count = entity.count
            }).ToList();

            return claimReports;
        }
        private bool IsValidMonth(string month)
        {
            string[] validMonthNames = new string[]
            {
            "Jan", "Feb", "March", "April", "May", "June",
            "July", "Aug", "Sept", "Oct", "Nov", "Dec"
            };

            return validMonthNames.Contains(month, StringComparer.OrdinalIgnoreCase);
        }
        private bool IsValidYear(int year)
        {

            DateTime currentDate = DateTime.Now;
            if (year > currentDate.Year)
                return false;
            return true;
        }

        private bool IsFutureMonth(string month)
        {
            int CurrMonth = DateTime.Now.Month;
            int inputMonth = MonthNameToNumber(month);
            if (inputMonth > CurrMonth || inputMonth==-1)
              return false;
            else return true;
        }

        private int MonthNameToNumber(object month)
        {
            string[] monthNames = { "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec" };
            for (int i = 0; i < monthNames.Length; i++)
            {
                if (string.Compare((string?)month, monthNames[i], true) == 0)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        //Exceptions for Endpoint 7
        public class InvalidMonthException : Exception
        {
            public InvalidMonthException(string message) : base(message) { }
        }
        public class InvalidYearException : Exception
        {
            public InvalidYearException(string message) : base(message) { }
        }
        public class FutureMonException : Exception
        {
            public FutureMonException(string message) : base(message) { }
        }
    }
}
