using ApplicationCore.Services;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class SaturdayStayCalculatorServiceTests
    {
        private SaturdayStayCalculatorService _saturdayStayCalculatorService;

        [SetUp]
        public void Setup()
        {
            _saturdayStayCalculatorService = new SaturdayStayCalculatorService();
        }

        [TestCase("2017-09-17T00:00:00", "2017-09-07T00:00:00")]
        public void LongStayThrowsAnErrorWhenStartDateIsGreaterThanEndDate(DateTime startDate, DateTime endDate)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _saturdayStayCalculatorService.Calculate(startDate, endDate));
        }


        [TestCase("2017-09-07T00:00:00", "2017-09-07T00:00:00", 0)]
        [TestCase("2017-09-07T00:00:00", "2017-09-07T00:02:00", 0)]
        [TestCase("2017-09-07T00:00:00", "2017-09-07T02:15:00", 5)]
        [TestCase("2017-09-07T10:00:00", "2017-09-07T14:00:00", 10)]
        public void LongStayCalculatesTotalCharge(DateTime startDate, DateTime endDate, decimal expectedResult)
        {
            // Act
            decimal result = _saturdayStayCalculatorService.Calculate(startDate, endDate);

            // Assert
            Assert.That(actual: result, Is.EqualTo(expected: expectedResult));
        }
    }
}