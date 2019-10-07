using System.Collections.Generic;

namespace INOM.Entities.Services.Parameters.Dto.InstrumentMarket
{
    public class InstrumentMarketApprovChangeDto
    {
        public InstrumentMarketHist InstrumentMarketHistToSave { get; set; }
        public List<InstrumentMarketMarketHist> InstrumentMarketMarketsHistToSave { get; set; }

        public INOM.Entities.InstrumentMarket InstrumentMarketToDelete { get; set; }
        public List<InstrumentMarketMarket> InstrumentMarketMarketsToDelete { get; set; }

        public INOM.Entities.InstrumentMarket InstrumentMarketNewToSave { get; set; }
        public List<InstrumentMarketMarket> InstrumentMarketMarketsNewToSave { get; set; }

        public InstrumentMarketPend InstrumentMarketPendToDelete { get; set; }
        public List<InstrumentMarketMarketPend> InstrumentMarketMarketsPendToDelete { get; set; }



        public InstrumentMarketApprovChangeDto()
        {
            this.InstrumentMarketMarketsHistToSave = new List<InstrumentMarketMarketHist>();
            this.InstrumentMarketMarketsToDelete = new List<InstrumentMarketMarket>();
            this.InstrumentMarketMarketsNewToSave = new List<InstrumentMarketMarket>();
            this.InstrumentMarketMarketsPendToDelete = new List<InstrumentMarketMarketPend>();
        }
    }
}
