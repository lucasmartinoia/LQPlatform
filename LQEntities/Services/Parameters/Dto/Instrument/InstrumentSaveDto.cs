using System;
using System.Collections.Generic;

namespace INOM.Entities.Services.Parameters.Dto.Instrument
{
    /// <summary>
    /// Class of save InstrumentFamily
    /// </summary>
    public class InstrumentSaveDto
    {
        public int InstrumentFamilyID { get; set; }
        public string Name { get; set; }
        public int MandatoryMarketID { get; set; }
        public int SuggestedMarketID { get; set; }
        public bool? SettlementTermCash { get; set; }
        public bool? SettlementTerm24hs { get; set; }
        public bool? SettlementTerm48hs { get; set; }
        public bool? SettlementTerm72hs { get; set; }
        public bool? SettlementTerm96hs { get; set; }
        public bool? SettlementTerm120hs { get; set; }
        public DateTime? SetupDateTime { get; set; }
        public string SetupUser { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        public string VerifiedUser { get; set; }
        public List<InstrumentFamilyMarketDto> InstrumentFamilyMarkets { get; set; }
    }
}
