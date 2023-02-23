using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correios.App.Models.Response
{
    public class PackageResponse
    {
        public Guid Id { get; set; }

        private string _code;

        public PackageResponse(string code)
        {
            SetCode(code);
            TrackingHistory = new List<PackageTracking>();
        }

        public string Code { get { return _code; } }
        public IList<PackageTracking> TrackingHistory { get; private set; }
        public PackageTracking LastStatus { get { return TrackingHistory.FirstOrDefault(); } }
        public DateTime? ShipDate { get { return TrackingHistory.Last().Date; } }
        public bool IsValid { get { return TrackingHistory.Any(); } }

        private void SetCode(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length != 13)
                throw new ArgumentException("Código de objeto inválido.");

            _code = code;
        }

        public void AddTrackingInfo(PackageTracking tracking)
        {
            TrackingHistory.Add(tracking);
        }

        public void AddTrackingInfo(IEnumerable<PackageTracking> list)
        {
            foreach (var item in list)
            {
                AddTrackingInfo(item);
            }
        }


    }
}
