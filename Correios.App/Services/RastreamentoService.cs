using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Correios.App.Services
{
    public class RastreamentoService
    {
        public async Task<Package> GetPackageTrackingAsync(string packageCode)
        {
            var url = $"{PACKAGE_TRACKING_URL}/?id={packageCode}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            var response = await _httpClient.SendAsync(requestMessage);
            var html = await response.Content.ReadAsStringAsync();
            return Parser.ParsePackage(html);
        }

        public Package GetPackageTracking(string packageCode)
        {
            return GetPackageTrackingAsync(packageCode).RunSync();
        }
    }
}
