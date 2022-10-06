using ApplicationCore.Services;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class BusinessDaysCalculatorServiceTests
    {
        private BusinessDaysStayCalculatorService _businessDaysCalculatorService;

        [SetUp]
        public void Setup()
        {
            _businessDaysCalculatorService = new BusinessDaysStayCalculatorService();
        }

        [TestCase("2017-09-17T00:00:00", "2017-09-07T00:00:00")]
        public void ShortStayThrowsAnErrorWhenStartDateIsGreaterThanEndDate(DateTime startDate, DateTime endDate)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _businessDaysCalculatorService.Calculate(startDate, endDate));
        }

        [TestCase("2022-09-07T00:00:00", "2022-09-07T00:00:00", 0)]
        [TestCase("2022-09-07T08:00:00", "2022-09-07T08:15:00", 1.5)]
        [TestCase("2022-09-07T16:50:00", "2022-09-07T19:15:00", 4.5)]
        public void ShortStayCalculatesTotalCharge(DateTime startDate, DateTime endDate, decimal expectedResult)
        {
            // Act
            decimal result = _businessDaysCalculatorService.Calculate(startDate, endDate);

            // Assert
            Assert.That(actual: result, Is.EqualTo(expected: expectedResult));
        }
    }
}