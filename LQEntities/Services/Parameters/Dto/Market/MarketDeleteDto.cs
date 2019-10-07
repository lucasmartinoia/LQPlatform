using System;

namespace INOM.Entities.Services.Parameters.Dto.Market
{
    public class MarketDeleteDto
    {
        public int? MarketID { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        public string VerifiedUser { get; set; }
    }
}
