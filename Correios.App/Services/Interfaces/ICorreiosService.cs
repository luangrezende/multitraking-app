using Correios.App.Models;
using Correios.App.Models.Response;

namespace Correios.App.Services.Interfaces
{
    public interface ICorreiosService
    {
        Task<PackageResponse> TrackPackageByCode(string packageCode);

        Task<List<PackageResponse>> TrackManyPackagesByCode(string[] packageCodes);

        List<PackageResponse> VerifyIfContaisPackagesToDeliveryToday(List<PackageResponse> packages);

        void PrintResultPackagesToDelivery(List<PackageResponse> packages);
    }
}
