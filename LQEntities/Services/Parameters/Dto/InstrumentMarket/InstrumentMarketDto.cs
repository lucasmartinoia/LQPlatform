using System;
using System.Collections.Generic;
using System.Text;

namespace INOM.Entities.Services.Parameters.Dto.InstrumentMarket
{
    public class InstrumentMarketDto: InstrumentMarketListDto
    {
        public List<InstrumentMarketMarketDto> InstrumentMarkets { get; set; }
    }
}
