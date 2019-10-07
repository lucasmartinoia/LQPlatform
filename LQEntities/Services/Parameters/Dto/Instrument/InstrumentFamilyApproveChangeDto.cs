using System.Collections.Generic;

namespace INOM.Entities.Services.Parameters.Dto.Instrument
{
    public class InstrumentFamilyApprovChangeDto
    {
        public InstrumentFamilyHist InstrumentFamilyHistToSave { get; set; }
        public List<InstrumentFamilyMarketHist> InstrumentMarketsHistToSave { get; set; }

        public InstrumentFamily InstrumentFamilyToDelete { get; set; }
        public List<InstrumentFamilyMarket> InstrumentMarketsToDelete { get; set; }

        public InstrumentFamily InstrumentFamilyNewToSave { get; set; }
        public List<InstrumentFamilyMarket> InstrumentMarketsNewToSave { get; set; }

        public InstrumentFamilyPend InstrumentFamilyPendToDelete { get; set; }
        public List<InstrumentFamilyMarketPend> InstrumentMarketsPendToDelete { get; set; }



        public InstrumentFamilyApprovChangeDto()
        {
            this.InstrumentMarketsHistToSave = new List<InstrumentFamilyMarketHist>();
            this.InstrumentMarketsToDelete = new List<InstrumentFamilyMarket>();
            this.InstrumentMarketsNewToSave = new List<InstrumentFamilyMarket>();
            this.InstrumentMarketsPendToDelete = new List<InstrumentFamilyMarketPend>();
        }
    }
}
