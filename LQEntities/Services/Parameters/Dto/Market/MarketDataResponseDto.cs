using System.Collections.Generic;

namespace INOM.Entities.Services.Parameters.Dto.Market
{
    /// <summary>
    /// Calss of Market response
    /// </summary>
    public class MarketDataResponseDto : ResponseDto
    {
        public MarketDataDto Data { get; set; }

        public MarketDataResponseDto() { }

    }

    /// <summary>
    /// Class of Data Market
    /// </summary>
    public class MarketDataDto
    {
        public List<MarketListDto> Market { get; set; }
        public List<MarketDto> Markets { get; set; }


        public MarketDataDto()
        {
            //this.Markets = new List<MarketListDto>();
        }
    }
}
