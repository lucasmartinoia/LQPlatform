using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class MarketProduct
    {
        /// <summary>
        /// Market identifier.
        /// </summary>
        [Key]
        public int MarketID { get; set; }
        /// <summary>
        /// Product ID in Calypso.
        /// </summary>
        [Key]
        public string ProductID { get; set; }
        /// <summary>
        /// Handle product availability in the market.
        /// </summary>
        public bool Active { get; set; }
    }
}
