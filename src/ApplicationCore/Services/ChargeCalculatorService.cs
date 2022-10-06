using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Services
{
    public class ChargeCalculatorService : ITotalChargeCalculatorService
    {
        public readonly IEnumerable<IStayTypeChargeCalculatorService> _calculatorServices;
        public ChargeCalculatorService(IEnumerable<IStayTypeChargeCalculatorService> calculatorServices)
        {
            _calculatorServices = calculatorServices;
        }

        public decimal Calculate(DateTime start, DateTime end)
        {
            IStayTypeChargeCalculatorService calculator;

            switch (start.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    calculator = _calculatorServices.First(c => c.StayType == Constants.StayTypeEnum.SundayStay);
                    break;
                case DayOfWeek.Saturday:
                    calculator = _calculatorServices.First(c => c.StayType == Constants.StayTypeEnum.SaturdaryStay);
                    break;
                default:
                    calculator = _calculatorServices.First(c => c.StayType == Constants.StayTypeEnum.BusinessDaysStay);
                    break;

            }

            return calculator.Calculate(start, end);
        }
    }
}
