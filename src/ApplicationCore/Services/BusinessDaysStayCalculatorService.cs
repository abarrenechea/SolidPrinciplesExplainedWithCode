using ApplicationCore.Constants;
using ApplicationCore.Interfaces;
using System;

namespace ApplicationCore.Services
{
    public class BusinessDaysStayCalculatorService : IStayTypeChargeCalculatorService
    {
        private const decimal FeePerHour = 1.5m;

        public StayTypeEnum StayType
        {
            get
            {
                return StayTypeEnum.SaturdaryStay;
            }
        }

        public decimal Calculate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("End date must be greater than start date");
            }

            decimal diffHours = (decimal)(endDate - startDate).TotalHours;
            decimal totalHours = Math.Ceiling(diffHours);

            decimal totalCharge = totalHours * FeePerHour;
            return Math.Round(totalCharge, CarParkConstants.DecimalsInResult);
        }
    }
}
