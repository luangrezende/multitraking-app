using Correios.App.Extensions;
using Correios.App.Services;
using Correios.App.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MultiTracking.Console.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
            var config = configuration.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Require services
            var correiosService = serviceProvider.GetRequiredService<ICorreiosService>();

            //Run services
            RunCorreiosService(correiosService, config);
        }

        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICorreiosService, CorreiosService>();
        }

        private static void RunCorreiosService(ICorreiosService correiosService, IConfiguration config)
        {
            var codes = config
               .GetSection("Correios:Codes")
               .GetChildren()
               .Select(x => x.Value)
               .ToArray();

            var result = correiosService.TrackManyPackagesByCode(codes).RunSync();
            var resultFiltered = correiosService.VerifyIfContaisPackagesToDeliveryToday(result);

            correiosService.PrintResultPackagesToDelivery(resultFiltered);
        }
    }
}