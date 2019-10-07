using System;
using System.Collections.Generic;

namespace INOM.Entities.Services.Parameters.Dto.Instrument
{
    /// <summary>
    /// Class of mapper to InstrumentFamily
    /// </summary>
    public class InstrumentFamilyDto: InstrumentFamilyListDto
    {
        public bool SettlementTermCash { get; set; }
        public bool SettlementTerm24hs { get; set; }
        public bool SettlementTerm48hs { get; set; }
        public bool SettlementTerm72hs { get; set; }
        public bool SettlementTerm96hs { get; set; }
        public bool SettlementTerm120hs { get; set; }
        public DateTime? SetupDateTime { get; set; }
        public string SetupUser { get; set; }
        public List<InstrumentFamilyMarketDto> InstrumentFamilyMarkets { get; set; }
    }
}
