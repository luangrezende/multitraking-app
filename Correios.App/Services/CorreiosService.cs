using Correios.App.Consts;
using Correios.App.Extensions;
using Correios.App.Helpers;
using Correios.App.Models.Response;
using Correios.App.Services.Interfaces;

namespace Correios.App.Services
{
    public class CorreiosService : ICorreiosService
    {
        private const string PACKAGE_TRACKING_URL = "https://www.linkcorreios.com.br";
        private readonly HttpClient _httpClient;

        public CorreiosService()
        {
            _httpClient = new HttpClient();
        }

        public List<PackageResponse> VerifyIfContaisPackagesToDeliveryToday(List<PackageResponse> packages)
        {
            return packages.Where(x => x.LastStatus != null && x.LastStatus.Status.Equals(DescriptionsConsts.SAIU_PARA_ENTREGA)).ToList();
        }

        public void PrintResultPackagesToDelivery(List<PackageResponse> packages)
        {
            Console.Clear();

            if (packages.Count <= 0)
            {
                ConsoleInterfaceHelper.WriteLineWithColor($"*** CORREIOS ***", ConsoleColor.Yellow);
                Console.WriteLine($"Sem entregas até o momento");
                Console.WriteLine();
            }

            foreach (var package in packages.Where(x => x.LastStatus != null))
            {
                Console.WriteLine($"*** CORREIOS ***");
                Console.WriteLine($"Codigo: {package.Code}");
                VerifyIfIsToday(package.LastStatus.Date);

                if (package.LastStatus.Status.Equals(DescriptionsConsts.SAIU_PARA_ENTREGA))
                {
                    ConsoleInterfaceHelper.WriteLineWithColor(
                        $"Status: {package.LastStatus.Status}",
                        ConsoleColor.Green);
                }
                else
                {
                    ConsoleInterfaceHelper.WriteLineWithColor(
                        $"Status: {package.LastStatus.Status}",
                        ConsoleColor.Yellow);
                }

                Console.WriteLine();
            }
        }

        private static void VerifyIfIsToday(DateTime date)
        {
            if (date.ToString("dd/MM/yyyy").Equals(DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy")))
            {
                ConsoleInterfaceHelper.WriteLineWithColor(
                        $"Data: {date}",
                        ConsoleColor.Green);
            }

            Console.WriteLine($"Data: {date}");
        }

        public async Task<PackageResponse> TrackPackageByCode(string packageCode)
        {
            var url = $"{PACKAGE_TRACKING_URL}/?id={packageCode}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            var response = await _httpClient.SendAsync(requestMessage);
            var html = await response.Content.ReadAsStringAsync();

            return ParserHelpers.ParsePackage(html);
        }

        public async Task<List<PackageResponse>> TrackManyPackagesByCode(string[] packageCodes)
        {
            var packageList = new List<PackageResponse>();
            foreach (var code in packageCodes)
            {
                packageList.Add(TrackPackageByCode(code).RunSync());
            }

            return packageList;
        }
    }
}
