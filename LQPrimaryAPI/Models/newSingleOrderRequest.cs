using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public class newSingleOrderRequest
    {
        public newSingleOrderRequest()
        {
            this.instrumentId = new InstrumentId();
        }

        public InstrumentId instrumentId { get; set; }
        public double price { get; set; }
        public int orderQty { get; set; }
        public string ordType { get; set; }
        public string side { get; set; }
        public string timeInForce { get; set; }
        public string account { get; set; }
        public bool? cancelPrevious { get; set; }
        public bool? iceberg { get; set; }
        public string expireDate { get; set; }
        public int? displayQty { get; set; }
    }
}
