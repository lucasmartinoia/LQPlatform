using System;

namespace INOM.Entities.Services.Parameters.Dto.Market
{
    /// <summary>
    /// Class of save market
    /// </summary>
    public class MarketSaveDto
    {
        public int? MarketID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public DateTime? SetupDateTime { get; set; }
        public string SetupUser { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        public string VerifiedUser { get; set; }
        public string Depositor { get; set; }
        public string Custody { get; set; }
        public string MarketStartTime { get; set; }
        public string MarketEndTime { get; set; }
        public bool? OwnPortfolio { get; set; }
        public bool? ManualOperation { get; set; }
    }
}
