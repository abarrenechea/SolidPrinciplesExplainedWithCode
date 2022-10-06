using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<IStayTypeChargeCalculatorService, SaturdayStayCalculatorService>();
                    services.AddSingleton<IStayTypeChargeCalculatorService, SaturdayStayCalculatorService>();
                    services.AddSingleton<IStayTypeChargeCalculatorService, SundayStayCalculatorService>();
                    services.AddSingleton<ITotalChargeCalculatorService, ChargeCalculatorService>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
