using System;

namespace INOM.Entities.Services.Parameters.Dto.Instrument
{
    /// <summary>
    /// Class of mapper to InstrumentFamily
    /// </summary>
    public class InstrumentFamilyListDto
    {
        public int InstrumentFamilyID { get; set; }
        public string Name { get; set; }
        public int? MandatoryMarketID { get; set; }
        public int? SuggestedMarketID { get; set; }
        public string MandatoryMarket { get; set; }
        public string SuggestedMarket { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        public string VerifiedUser { get; set; }
    }
}
