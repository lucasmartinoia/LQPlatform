using System;
using System.Collections.Generic;

namespace INOM.Entities.Services.Parameters.Dto.InstrumentMarket
{
    public class InstrumentMarketSaveDto
    {
        public int InstrumentID { get; set; }
        public DateTime? SetupDateTime { get; set; }
        public string SetupUser { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        public string VerifiedUser { get; set; }

        public List<InstrumentMarketMarketDto> InstrumentMarkets { get; set; }
    }
}
