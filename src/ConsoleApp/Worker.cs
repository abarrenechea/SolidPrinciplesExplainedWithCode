using ApplicationCore.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITotalChargeCalculatorService _calculatorServices;

        public Worker(
            ILogger<Worker> logger,
            ITotalChargeCalculatorService calculatorServices)
        {
            _logger = logger;
            _calculatorServices = calculatorServices;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DateTime startDate = default;
                DateTime endDate = default;

                bool invalidStartDate = true;
                bool invalidEndDate = true;

                while (invalidStartDate)
                {
                    Console.WriteLine("Enter a start date using the following format: yyyy-mm-dd hh:mm:ss");
                    try
                    {
                        startDate = DateTime.Parse(Console.ReadLine());
                        invalidStartDate = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid start date.");
                    }
                }

                while(invalidEndDate)
                {
                    Console.WriteLine("Enter a end date using the following format: yyyy-mm-dd hh:mm:ss");
                    try
                    {
                        endDate = DateTime.Parse(Console.ReadLine());
                        invalidEndDate = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid end date.");
                    }
                }

                decimal charge = _calculatorServices.Calculate(startDate, endDate);

                Console.WriteLine();
                Console.WriteLine($"The total charge is: {charge}");
                Console.WriteLine("********");
                Console.WriteLine();
            }
        }
    }
}
