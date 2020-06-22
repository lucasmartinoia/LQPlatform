using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LatamQuants.PrimaryAPI.Models
{
    public class Trade
    {
        [JsonProperty("price")]
        public double price { get; set; }

        [JsonProperty("size")]
        public double size { get; set; }

        [JsonProperty("datetime")]
        public string datetime { get; set; }

        [JsonProperty("servertime")]
        public string servertime { get; set; }

        public string symbol { get; set; }
    }
}
