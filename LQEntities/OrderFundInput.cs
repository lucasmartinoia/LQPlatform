using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace INOM.Entities
{
    public class OrderFundInput
    {
        /// </summary>
        public string OrderType { get; set; }
        public string ProductCodeType { get; set; }
        public string FundID { get; set; }

        public DateTime ExecutionDate { get; set; }
        public string RescueType { get; set; }

        public decimal Shares { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }
        public string CustodyAccountNo { get; set; }
        public bool Scheduled { get; set; }
        public int OnlyMigration { get; set; }

        //public string Prenote { get; set; }
        public string OrderInputMode { get; set; }
        //public string SettlementMethod { get; set; }
        public string BrokerID { get; set; }
        public string ChannelID { get; set; }
        public string OperatorID { get; set; }

        public string ClientID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string Action { get; set; }

        public string Discriminator { get; set; }
   //     public DateTime LastUpdate { get; set; }

        public string ProductType { get; set; }
        public int TypeTransfer { get; set; }
        public string Comments { get; set; }
        //      public string Status { get; set; }
        public int ExternalReference { get; set; }
        public int LinkOrderID { get; set; }
        private float exchangeRate;
        public bool NewContractSignature { get; set; }
        public float ExchangeRate
        {
            get
            {
                if (this.exchangeRate == 0)
                    return 1;
                else

                    return this.exchangeRate;
            }
            set
            {
                if (value == 0)
                    exchangeRate = 1;
                else
                    exchangeRate = value;
            }
        }
        //    public int? InstructionID { get; set; }
        [JsonProperty("Settlements")]
        public List<SettlementInput> Settlements { get; set; }
        public bool RecycleActive
        {
            get
            {
                return false;
            }
            set { }
        }

        public int? RecycleFrequence { get; set; }

        public string RecycleLimitTime { get; set; }
        public string OperationsStockTicket { get; set; }
    }
}
