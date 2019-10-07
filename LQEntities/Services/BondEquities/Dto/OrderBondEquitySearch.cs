using System;
using System.Collections.Generic;

namespace INOM.Entities.Services.BondEquities.Dto
{
    public class OrderBondEquitySearch
    {
        public string BrokerID { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string ChannelID { get; set; }
        public string OperatorID { get; set; }
        public string ClientID { get; set; }
        public string Status { get; set; }
        public string ProductType { get; set; }
        public int OrderIDFrom { get; set; }
        public int OrderIDTo { get; set; }
        public int OrderNumberFrom { get; set; }
        public int OrderNumberTo { get; set; }
        public string InstrumentID { get; set; }
        public string CustodyAccountNo { get; set; }
        public string OrderType { get; set; }
        public int? Scheduled { get; set; }
        public bool? NotBackOffice { get; set; }
        public decimal AmountFrom { get; set; }
        public decimal AmountTo { get; set; }
        public int ExternalReferenceFrom { get; set; }
        public int ExternalReferenceTo { get; set; }
        public int BOTradeIDFrom { get; set; }
        public int BOTradeIDTo { get; set; }
        public int? InstructionID { get; set; }
        public int? OrderNumber { get; set; }
        public int? InstructionNumber { get; set; }
        public string Comments { get; set; }
        public List<int> OrderList { get; set; }
        public List<int> ExternalReferenceList { get; set; }
    }
}

