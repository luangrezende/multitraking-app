using Correios.App.Models;

namespace Correios.App.Services.Interfaces
{
    public interface ICorreiosService
    {
        Task<Package> GetPackageTrackingAsync(string packageCode);

        List<Package> VerifyIfContaisPackagesToDeliveryToday(List<Package> packages);

        void PrintResultPackagesToDelivery(List<Package> packages);
    }
}
