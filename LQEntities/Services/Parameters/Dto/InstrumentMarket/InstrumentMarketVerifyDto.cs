using System;

namespace INOM.Entities.Services.Parameters.Dto.InstrumentMarket
{
    public class InstrumentMarketVerifyDto
    {
        public int InstrumentID { get; set; }
        public bool? Approved { get; set; }
        public string RejectReason { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        public string VerifiedUser { get; set; }
    }
}
