using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public abstract class Settlement
    {
        [Key]
        public int SettlementID { get; set; }
        [Required]
        public string Discriminator { get; set; }
        public virtual Order Order { get; set; }
        public int OrderID { get; set; }

        /// <summary>
        /// Settlement destination: OR = Order settlement; CO = Commission settlement.
        /// </summary>
        [StringLength(2)]
        public string Destination { get; set; }
    }
}
