using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.PrimaryAPI.Models
{
    public class Instrument
    {
        public InstrumentId instrumentId { get; set; }
        public string cficode { get; set; }
    }
}
