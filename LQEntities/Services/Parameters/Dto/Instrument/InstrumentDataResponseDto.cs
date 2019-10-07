using System.Collections.Generic;

namespace INOM.Entities.Services.Parameters.Dto.Instrument
{
    /// <summary>
    /// Calss of InstrumentFamily response
    /// </summary>
    public class InstrumentDataResponseDto : ResponseDto
    {
        public InstrumentDataDto Data { get; set; }

        public InstrumentDataResponseDto() { }

    }

    /// <summary>
    /// Class of Data IsntrumenFamily
    /// </summary>
    public class InstrumentDataDto
    {
        public List<InstrumentFamilyListDto> Instruments { get; set; }
        public List<InstrumentFamilyDto> Instrument { get; set; }


        public InstrumentDataDto() { }
    }
}
