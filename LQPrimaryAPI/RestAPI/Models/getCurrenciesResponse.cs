using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getCurrenciesResponse
    {
        public class Currency
        {
            public double rate { get; set; }
            public string currency { get; set; }
            public string description { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public List<Currency> currencies { get; set; }
        }
    }
}
