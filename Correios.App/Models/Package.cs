using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correios.App.Models
{
    public class PackageEntity
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        //public PackageTracking LastStatus { get; set; }
    }
}
