using System;

namespace INOM.Entities.Services.Parameters.Dto.Market
{
    /// <summary>
    /// Class of mapper to Market
    /// </summary>
    public class MarketListDto: MarketDto
    {
        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime? SetupDateTime { get; set; }
        /// <summary>
        /// User of creation
        /// </summary>
        public string SetupUser { get; set; }
        /// <summary>
        /// Depositante para la liquidación
        /// </summary>
        public string Depositor { get; set; }
        /// <summary>
        /// Comitente para la liquidación
        /// </summary>
        public string Custody { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool OwnPortfolio { get; set; }
        /// <summary>
        /// Indica si la operatoria es manual o automática
        /// </summary>
        public bool ManualOperation { get; set; }
    }
}
