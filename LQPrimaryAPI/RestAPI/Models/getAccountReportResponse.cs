using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getAccountReportResponse
    {
        public class DetailedCash
        {
            public decimal EUR { get; set; }
            public decimal ARS { get; set; }
            [JsonProperty("ARS BCRA")]
            public decimal ARS_BCRA { get; set; }
            [JsonProperty("USD G")]
            public decimal USD_G { get; set; }
            [JsonProperty("U$S")]
            public decimal USS { get; set; }
            [JsonProperty("USD D")]
            public decimal USD_D { get; set; }
            [JsonProperty("USD R")]
            public decimal USD_R { get; set; }
            [JsonProperty("USD C")]
            public decimal USD_C { get; set; }
        }

        public class Cash
        {
            public decimal totalCash { get; set; }
            public DetailedCash detailedCash { get; set; }
        }

        public class AccountValue
        {
            public Cash cash { get; set; }
            public decimal dailyDiff { get; set; }
            public decimal movements { get; set; }
            public decimal portfolio { get; set; }
            public decimal credit { get; set; }
            public decimal total { get; set; }
        }

        public class DetailedCurrencyBalance
        {
            public CurrencyDetailedBalance EUR { get; set; }
            public CurrencyDetailedBalance ARS { get; set; }
            [JsonProperty("ARS BCRA")]
            public CurrencyDetailedBalance ARS_BCRA { get; set; }
            [JsonProperty("U$S")]
            public CurrencyDetailedBalance USS { get; set; }
            [JsonProperty("USD G")]
            public CurrencyDetailedBalance USD_G { get; set; }
            [JsonProperty("USD D")]
            public CurrencyDetailedBalance USD_D { get; set; }
            [JsonProperty("USD C")]
            public CurrencyDetailedBalance USD_C { get; set; }
            [JsonProperty("USD R")]
            public CurrencyDetailedBalance USD_R { get; set; }

        }

        public class CurrencyDetailedBalance
        {
            public decimal consumed { get; set; }
            public decimal available { get; set; }
        }

        public class CurrencyBalance
        {
            public DetailedCurrencyBalance detailedCurrencyBalance { get; set; }
        }

        public class DetailedAccountReport
        { 
            public CurrencyBalance currencyBalance { get; set; }
            public AccountValue accountValue { get; set; }
            public AccountValue availableToOperate { get; set; }
        }

        public class DetailedAccountReports
        {
            public DetailedAccountReport T_PLUS_2 { get; set; }
            public DetailedAccountReport NEXT_DAY { get; set; }
            public DetailedAccountReport T_PLUS_3 { get; set; }
            public DetailedAccountReport CASH { get; set; }
        }

        public class AccountData
        {
            public long lastCalculation { get; set; }
            public string accountName { get; set; }
            public string marketMember { get; set; }
            public string marketMemberIdentity { get; set; }
            public int collateral { get; set; }
            public int margin { get; set; }
            public int availableToCollateral { get; set; }
            public DetailedAccountReports detailedAccountReports { get; set; }
            public bool hasError { get; set; }
            public object errorDetail { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public string message { get; set; }
            public string description { get; set; }
            public AccountData accountData { get; set; }
        }
    }
}
