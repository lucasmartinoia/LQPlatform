using System;

namespace INOM.Entities.Services.Parameters.Dto.InstrumentMarket
{
    public class InstrumentMarketListDto
    {
        public int InstrumentID { get; set; }
        public string CVDescription { get; set; }
        public string ProductCodeCV { get; set; }
        public string ProductCodeEuroclear { get; set; }
        public string ProductCodeIsin { get; set; }
        public string ProductCodeDtc { get; set; }
        public string ProductCodeMae { get; set; }
        public string ProductCodeRic { get; set; }
        public string ProductCodeTicker { get; set; }
        public DateTime SetupDateTime { get; set; }
        public string SetupUser { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        public string VerifiedUser { get; set; }
    }
}