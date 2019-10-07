using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace INOM.Entities.Services.BondEquities.Dto
{
    public class OrderBondEquityInput
    {
        /// </summary>
        public string BrokerID { get; set; }
        public string ChannelID { get; set; }
        public string OperatorID { get; set; }
        public string ClientID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string Action { get; set; }
        public Boolean Confirmed { get; set; }
        public string ProductType { get; set; }
        public string Comments { get; set; }
        public Boolean RecycleActive { get; set; }
        public int RecycleFrequence { get; set; }
        public string RecycleLimitTime { get; set; }
        public float ExchangeRate { get; set; }
        public string OperationsStockTicket { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public double Price { get; set; }
        public decimal Shares { get; set; }
        public string CustodyAccountNo { get; set; }
        public int ExternalReference { get; set; }
        public Boolean Scheduled { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string AuthorizerID { get; set; }
        public Boolean OfficialLetter { get; set; }
        public int OfficialLetterNo { get; set; }
        public DateTime SettleDate { get; set; }
        public int SettleTerm { get; set; }
        public string MarketName { get; set; }
        public string InstrumentID { get; set; }
        public string OrderType { get; set; }
        public string ProductCodeType { get; set; }
        public DateTime ExpireDate { get; set; }
        public string ExpireTime { get; set; }
        public Boolean Buy { get; set; }
        public double StopLoss { get; set; }
        public double TakeProfit { get; set; }
        public int OrderLife { get; set; }
        public Boolean PositionOperation { get; set; }
        public string ExcludedMarkets { get; set; }

        [JsonProperty("Settlements")]
        public List<SettlementInput> Settlements { get; set; }

        [JsonProperty("Bonuses")]
        public List<Bonus> Bonuses { get; set; }
    }
}
