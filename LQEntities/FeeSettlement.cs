using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public abstract class FeeSettlement
    {
        /// <summary>
        /// FeeSettlement ID.
        /// </summary>
        [Key]
        public int FeeSettlementID { get; set; }

        public int ExternalReference { get; set; }

        /// <summary>
        /// Who is liquidated.
        /// </summary>
        [StringLength(50)]
        public string TradeCounterParty { get; set; }
        /// <summary>
        /// Who is liquidated.
        /// </summary>
        [StringLength(50)]
        public string TradeBook { get; set; }
        
        /// <summary>
        /// Amount currency.
        /// </summary>
        [StringLength(5)]
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
        public string BackOfficeStatus { get; set; }
        public string BackOfficeFeeTransferID { get; set; }
        public string BackOfficeCommStatus { get; set; }
        public DateTime? LastUpdate { get; set; }

        public decimal TaxAmount { get; set; }
        [StringLength(20)]
        public string TaxCounterParty { get; set; }
        [StringLength(5)]
        public string TaxCurrency { get; set; }

        public virtual List<FeeSettlementErrorLog> FeeSettlementErrorLog { get; set; }
    }
}
