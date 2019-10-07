using System;
using System.Collections.Generic;

namespace INOM.Entities
{
    public class FeeSettlementFundResponse
    {
        /// <summary>
        /// FeeSettlement ID.
        /// </summary>
        public int FeeSettlementID { get; set; }

        public int ExternalReference { get; set; }

        /// <summary>
        /// Who is liquidated.
        /// </summary>
        public string TradeCounterParty { get; set; }
        /// <summary>
        /// Who is liquidated.
        /// </summary>
        public string TradeBook { get; set; }

        /// <summary>
        /// Amount currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Amount to be transfered.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// FeeSettlementDate:  Delivery date of the settlement.
        /// </summary>
        public DateTime FeeSettlementDate { get; set; }

        /// <summary>
        /// SettlementDate:  Settlement date.
        /// </summary>
        public DateTime SettleDate { get; set; }

        /// <summary>
        /// CustodyBrokerID.
        /// </summary>
        public string CustodyBrokerID { get; set; }
        public string BrokerID { get; set; }
        public string Status { get; set; }
        public decimal TaxAmount { get; set; }
        public string TaxCounterParty { get; set; }
        public string TaxCurrency { get; set; }

        public List<FeeSettlementErrorLog> FeeSettlementErrorLog { get; set; }

        public FeeSettlementFundResponse()
        {
            FeeSettlementErrorLog = new List<FeeSettlementErrorLog>();
        }
    }
}
