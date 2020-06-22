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
            public double EUR { get; set; }
            public double ARS { get; set; }
            [JsonProperty("ARS BCRA")]
            public double ARS_BCRA { get; set; }
            [JsonProperty("USD G")]
            public double USD_G { get; set; }
            [JsonProperty("U$S")]
            public double USS { get; set; }
            [JsonProperty("USD D")]
            public double USD_D { get; set; }
            [JsonProperty("USD R")]
            public double USD_R { get; set; }
            [JsonProperty("USD C")]
            public double USD_C { get; set; }
        }

        public class Cash
        {
            public double totalCash { get; set; }
            public DetailedCash detailedCash { get; set; }
        }

        public class AccountValue
        {
            public Cash cash { get; set; }
            public double? movements { get; set; }
            public double? credit { get; set; }
            public double? total { get; set; }
            public double? pendingMovements { get; set; }
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
            public double consumed { get; set; }
            public double available { get; set; }
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
            public long settlementDate { get; set; }
        }

        public class DetailedAccountReports
        {
            [JsonProperty("0")]
            public DetailedAccountReport CASH { get; set; }
            [JsonProperty("1")]
            public DetailedAccountReport NEXT_DAY { get; set; }
            [JsonProperty("2")]
            public DetailedAccountReport T_PLUS_2 { get; set; }
            [JsonProperty("3")]
            public DetailedAccountReport T_PLUS_3 { get; set; }
        }

        public class AccountData
        {
            public string lastCalculation { get; set; }
            public string accountName { get; set; }
            public string marketMember { get; set; }
            public string marketMemberIdentity { get; set; }
            public double collateral { get; set; }
            public double margin { get; set; }
            public double availableToCollateral { get; set; }
            public DetailedAccountReports detailedAccountReports { get; set; }
            public bool hasError { get; set; }
            public string errorDetail { get; set; }
            public double portfolio { get; set; }
            public double ordersMargin { get; set; }
            public double currentCash { get; set; }
            public double dailyDiff { get; set; }
            public double uncoveredMargin { get; set; }
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
