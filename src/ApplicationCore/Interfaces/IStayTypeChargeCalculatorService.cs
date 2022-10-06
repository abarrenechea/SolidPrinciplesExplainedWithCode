using ApplicationCore.Constants;
using System;

namespace ApplicationCore.Interfaces
{
    public interface IStayTypeChargeCalculatorService
    {
        StayTypeEnum StayType { get;  }
        decimal Calculate(DateTime start, DateTime end);
    }
}
