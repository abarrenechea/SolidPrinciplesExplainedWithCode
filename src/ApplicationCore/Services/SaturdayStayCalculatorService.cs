using ApplicationCore.Constants;
using ApplicationCore.Interfaces;
using System;

namespace ApplicationCore.Services
{
    public class SaturdayStayCalculatorService : IStayTypeChargeCalculatorService
    {
        private const decimal FeePerHour = 5m;
        private const decimal FreeHours = 2m;

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
            decimal totalHours = Math.Max(0, Math.Ceiling(diffHours - FreeHours));

            decimal totalCharge = totalHours * FeePerHour;
            return Math.Round(totalCharge, CarParkConstants.DecimalsInResult);
        }
    }
}
