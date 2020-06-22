using Newtonsoft.Json;
using LatamQuants.PrimaryAPI.WebSocket.Serialization;

namespace LatamQuants.PrimaryAPI.Models
{
    [JsonConverter(typeof(EntryJsonSerializer))]
    public enum Entry
    {
        /// <summary>Best buy offer in the Market Book.</summary>
        Bids, 
        
        /// <summary>Best sell offer in the Market Book.</summary>
        Offers,

        /// <summary>Last price traded in the Market Book.</summary>
        Last,

        /// <summary>Opening price in the Market Book.</summary>
        Open,

        /// <summary>Closing price in the Market Book.</summary>
        Close,

        /// <summary>Settlement price (only for futures).</summary>
        SettlementPrice,
        
        /// <summary>Highest price traded.</summary>
        SessionHighPrice,
        
        /// <summary>Lowest price traded.</summary>
        SessionLowPrice,
        
        /// <summary>Traded volume in contracts/nominal.</summary>
        Volume,
        
        /// <summary>Open interest in contracts (only for futures).</summary>
        OpenInterest,
        
        /// <summary>Calculated index value (only for indices).</summary>
        IndexValue,
        
        /// <summary>Effective traded volume.</summary>
        EffectiveVolume,
        
        /// <summary>Nominal traded volume.</summary>
        NominalVolume
    }

    #region String serialization

    internal static class EnumsToApiStrings
    {
        public static string ToApiString(this Entry value)
        {
            string sReturn = "";

            switch (value)
            {
                case Entry.Bids: sReturn = "BI"; break;
                case Entry.Offers: sReturn = "OF"; break;
                case Entry.Last: sReturn = "LA"; break;
                case Entry.Open: sReturn = "OP"; break;
                case Entry.Close: sReturn = "CL"; break;
                case Entry.SettlementPrice: sReturn = "SE"; break;
                case Entry.SessionHighPrice: sReturn = "HI"; break;
                case Entry.SessionLowPrice: sReturn = "LO"; break;
                case Entry.Volume: sReturn = "TV"; break;
                case Entry.OpenInterest: sReturn = "OI"; break;
                case Entry.IndexValue: sReturn = "IV"; break;
                case Entry.EffectiveVolume: sReturn = "EV"; break;
                case Entry.NominalVolume: sReturn = "NV"; break;
                default: sReturn = ""; break;
            }

            return sReturn;
        }

        public static Entry EntryFromApiString(string value)
        {
            Entry oReturn = Entry.Bids;

            switch (value)
            {
                case "BI": oReturn = Entry.Bids; break;
                case "OF": oReturn = Entry.Offers; break;
                case "LA": oReturn = Entry.Last; break;
                case "OP": oReturn = Entry.Open; break;
                case "CL": oReturn = Entry.Close; break;
                case "SE": oReturn = Entry.SettlementPrice; break;
                case "HI": oReturn = Entry.SessionHighPrice; break;
                case "LO": oReturn = Entry.SessionLowPrice; break;
                case "TV": oReturn = Entry.Volume; break;
                case "OI": oReturn = Entry.OpenInterest; break;
                case "IV": oReturn = Entry.IndexValue; break;
                case "EV": oReturn = Entry.EffectiveVolume; break;
                case "NV": oReturn = Entry.NominalVolume; break;
            }

            return oReturn;
        }
    }

    #endregion

    #region JSON Serialization

    internal class EntryJsonSerializer : EnumJsonSerializer<Entry>
    {
        protected override string ToString(Entry enumValue)
        {
            return enumValue.ToApiString();
        }

        protected override Entry FromString(string enumString)
        {
            return EnumsToApiStrings.EntryFromApiString(enumString);
        }
    }

    #endregion
}
