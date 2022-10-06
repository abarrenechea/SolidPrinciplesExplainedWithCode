using ApplicationCore.Constants;
using ApplicationCore.Interfaces;
using System;

namespace ApplicationCore.Services
{
    public class SundayStayCalculatorService : IStayTypeChargeCalculatorService
    {

        private const decimal FeePerHour = 6.0m;
        private const decimal FreeHours = 2m;

        public StayTypeEnum StayType
        {
            get
            {
                return StayTypeEnum.BusinessDaysStay;
            }
        }

        public decimal Calculate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("End date must be greater than start date");
            }

            decimal diffHours = (decimal)(endDate - startDate).TotalHours;
            decimal totalHours = Math.Max(0, Math.Ceiling(diffHours - FreeHours));

            decimal totalCharge = totalHours * FeePerHour;
            return Math.Round(totalCharge, CarParkConstants.DecimalsInResult);
        }
    }
}
