using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Models;
using ClaimManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClaimManagement.BLL.Services.MyPendingStatusReportService;

namespace ClaimManagement.BLL.Services
{

    //Endpoint 8
    public class MyPaymentOfClaimService : IPaymentOfClaimService
    {
        private readonly IPaymentOfClaimsRepository paymentofClaimsRepository;
        public MyPaymentOfClaimService(IPaymentOfClaimsRepository paymentOfClaimsRepository)
        {
            this.paymentofClaimsRepository = paymentOfClaimsRepository;
        }
        public List<ClaimPaymentReportDTO_EP8> GetPaymentStatusReportsByMonthAndYearByService(string month, int year)
        {
            if (!IsValidMon(month))
            {
                throw new InvalidMonException("Invalid month.");
            }

            if (!IsValidYr(year))
            {
                throw new InvalidYrException("Year Cannot be greater than Current Year.");
            }

            if (year == DateTime.Now.Year && !IsFutureMonth(month))
            {
                throw new FutMonException("Future Month");
            }

            List<PaymentOfClaims> paymentReports = paymentofClaimsRepository.GetPaymentStatusReportsByMonthAndYear(month, year);

            List<ClaimPaymentReportDTO_EP8> dtoList = paymentReports.Select(r => new ClaimPaymentReportDTO_EP8
            {
                reportId = r.reportId,
                payment = r.payment
            }).ToList();

            return dtoList;
        }
        private bool IsValidMon(string month)
        {
            string[] validMonthNames = new string[]
            {
            "Jan", "Feb", "March", "April", "May", "June",
            "July", "Aug", "Sept", "Oct", "Nov", "Dec"
            };

            return validMonthNames.Contains(month, StringComparer.OrdinalIgnoreCase);
        }
        private bool IsValidYr(int year)
        {
            int currentYear = DateTime.Now.Year;
            return year <= currentYear;
        }

        private bool IsFutureMonth(string month)
        {
            int CurrMonth = DateTime.Now.Month;
            int inputMonth = MonthNameToNumber(month);
            if (inputMonth > CurrMonth || inputMonth == -1)
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
        //Exceptions for Endpoint 8
        public class InvalidMonException : Exception
        {
            public InvalidMonException(string message) : base(message) { }
        }
        public class InvalidYrException : Exception
        {
            public InvalidYrException(string message) : base(message) { }
        }
        public class FutMonException : Exception
        {
            public FutMonException(string message) : base(message) { }
        }
    }
}
