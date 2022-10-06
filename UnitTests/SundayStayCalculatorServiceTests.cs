using ApplicationCore.Services;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class SundayStayCalculatorServiceTests
    {
        private SundayStayCalculatorService _sundayStayCalculatorService;

        [SetUp]
        public void Setup()
        {
            _sundayStayCalculatorService = new SundayStayCalculatorService();
        }

        [TestCase("2017-09-17T00:00:00", "2017-09-07T00:00:00")]
        public void ShortStayThrowsAnErrorWhenStartDateIsGreaterThanEndDate(DateTime startDate, DateTime endDate)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sundayStayCalculatorService.Calculate(startDate, endDate));
        }

        [TestCase("2017-09-07T00:00:00", "2017-09-07T00:00:00", 0)]
        [TestCase("2017-09-07T00:00:00", "2017-09-07T00:02:00", 0)]
        [TestCase("2017-09-07T00:00:00", "2017-09-07T02:15:00", 6)]
        [TestCase("2017-09-07T10:00:00", "2017-09-07T14:00:00", 12)]
        public void ShortStayCalculatesTotalCharge(DateTime startDate, DateTime endDate, decimal expectedResult)
        {
            // Act
            decimal result = _sundayStayCalculatorService.Calculate(startDate, endDate);

            // Assert
            Assert.That(actual: result, Is.EqualTo(expected: expectedResult));
        }
    }
}