using Correios.App.Services;
using Correios.App.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MultiTracking.Console.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Require services
            var correiosService = serviceProvider.GetRequiredService<ICorreiosService>();

            //Run services
            RunCorreiosService(correiosService);
        }

        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICorreiosService, CorreiosService>();
        }

        private static void RunCorreiosService(ICorreiosService correiosService)
        {
            var teste = correiosService.GetPackageTrackingAsync("NL382546014BR");
        }
    }
}