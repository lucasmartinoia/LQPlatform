using System;

namespace INOM.Entities.Services.Parameters.Dto.Market
{
    /// <summary>
    /// Class of mapper to Market
    /// </summary>
    public class MarketDto
    {
        /// <summary>
        /// Market identifier.
        /// </summary>
        public int MarketID { get; set; }
        /// <summary>
        /// Market name (i.e. BYMA, MAE, ROFEX).
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Market description (i.e. "BYMA es una nueva Bolsa de Valores que integra y representa a los principales actores del mercado de valores del país.").
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Handle market availability.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Modification date and time.
        /// </summary>
        public DateTime? ModifiedDateTime { get; set; }
        /// <summary>
        ///User of modification
        /// </summary>
        public string ModifiedUser { get; set; }
        /// <summary>
        /// Verifigin date and time.
        /// </summary>
        public DateTime? VerifiedDateTime { get; set; }
        /// <summary>
        /// Verifiying user 
        /// </summary>
        public string VerifiedUser { get; set; }
        /// <summary>
        /// Opening hours
        /// </summary>
        public string MarketStartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MarketEndTime { get; set; }
        /// <summary>
        /// Pending authorization: true | false
        /// </summary>
        public bool? Delete { get; set; }
    }
}
