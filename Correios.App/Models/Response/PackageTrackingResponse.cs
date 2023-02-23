namespace Correios.App.Models.Response
{
    public class PackageTrackingResponse
    {
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }

        public override string ToString()
        {
            return string.Format("{0:dd/MM/yyyy HH:mm} - ({1} -> {2}) - {3}", Date, Source, Destination, Status);
        }

    }
}
