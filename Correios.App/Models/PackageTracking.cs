using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correios.App.Models
{
    public class PackageTracking
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
