using Correios.App.Extensions;
using Correios.App.Helpers;
using Correios.App.Models;
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

        public List<Package> VerifyIfContaisPackagesToDeliveryToday(List<Package> packages)
        {
            return new List<Package>();
        }

        public void PrintResultPackagesToDelivery(List<Package> packages)
        {

        }

        public async Task<Package> GetPackageTrackingAsync(string packageCode)
        {
            var url = $"{PACKAGE_TRACKING_URL}/?id={packageCode}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            var response = await _httpClient.SendAsync(requestMessage);
            var html = await response.Content.ReadAsStringAsync();

            return ParserHelpers.ParsePackage(html);
        }
    }
}
