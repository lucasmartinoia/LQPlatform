using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INOM.Entities
{
    public class FundsInstruction
    {
        [Key]
        public int FundsInstructionID { get; set; }
        /// <summary>
        /// Market instruction ID.
        /// Inherited from MarketInstruction (1 to 1 relationship).
        /// </summary>
        public int MarketInstructionID { get; set; }

        /// <summary>
        /// Market instruction.
        /// </summary>
        //[Required]
        public virtual MarketInstruction MarketInstruction { get; set; }

        /// <summary>
        /// Order type: P = Promotion; C = Cancelation; T = Transfer between custody accounts.
        /// </summary>
        [Required]
        [StringLength(1)]
        public string InstructionFundType { get; set; }

        /// <summary>
        /// Funds Trades generated to satisfy this Funds Order.
        /// </summary>
        public virtual List<FundsTrade> FundsTrades { get; set; }

        public DateTime LastUpdate { get; set; }

        [NotMapped]
        public int InstructionID { get; set; }

        /// <summary>
        /// FundsOrder ID affected. 
        /// </summary>
        public int FundsOrderID { get; set; }

        public static void Save(FundsInstruction fundInstruction)
        {
            using (var db = new DBContext())
            {
                db.FundsInstructions.Add(fundInstruction);
                db.SaveChanges();
            }
        }
    }
}
