using System;
using System.Collections.Generic;

namespace INOM.Entities
{
    public class FeeSettlementsSearch
    {
        public List<int> ExternalReference { get; set; }
        public List<int> FeeSettlementIDs { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string TradeCounterParty { get; set; }
        public string TradeBook { get; set; }
        public int FundID { get; set; }
        public string Status { get; set; }
        public string BrokerID { get; set; }
        public string CustodyBrokerID { get; set; }
    }
}
