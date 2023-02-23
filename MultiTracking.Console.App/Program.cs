using Correios.App.Extensions;
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
            var codeList = new[] { 
                "NA995321775BR", 
                "NL396457447BR", 
                "NL395094573BR", 
                "NL391687369BR", 
                "NL388201864BR",
                "NL389426943BR",
                "NL382546014BR"
            };

            var result = correiosService.TrackManyPackagesByCode(codeList).RunSync();
            var resultFiltered = correiosService.VerifyIfContaisPackagesToDeliveryToday(result);

            correiosService.PrintResultPackagesToDelivery(resultFiltered);
        }
    }
}