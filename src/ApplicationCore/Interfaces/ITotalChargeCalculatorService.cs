using System;

namespace ApplicationCore.Interfaces
{
    public interface ITotalChargeCalculatorService
    {
        decimal Calculate(DateTime startDate, DateTime endDate);
    }
}
