using System.Collections.Generic;

namespace INOM.Entities.Services.Parameters.Dto.InstrumentMarket
{
    /// <summary>
    /// Calss of InstrumentFamily response
    /// </summary>
    public class InstrumentMarketDataResponseDto : ResponseDto
    {
        public InstrumentMarketDataDto Data { get; set; }

        public InstrumentMarketDataResponseDto() { }

    }

    /// <summary>
    /// Class of Data IsntrumenFamily
    /// </summary>
    public class InstrumentMarketDataDto
    {
        public List<InstrumentMarketListDto> Instruments { get; set; }
        public List<InstrumentMarketDto> Instrument { get; set; }


        public InstrumentMarketDataDto() { }
    }
}
