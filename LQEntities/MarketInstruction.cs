using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INOM.Entities
{
    public class MarketInstruction
    {
        /// <summary>
        /// Market instruction ID.
        /// </summary>
        [Key]
        public int MarketInstructionID { get; set; } // One sequence for all system market orders.
        /// <summary>
        /// Client instruction ID.
        /// </summary>
        public int InstructionID { get; set; }
        /// <summary>
        /// Client instruction.
        /// </summary>
        public virtual Instruction Instruction { get; set; }
        /// <summary>
        /// Market identifier.
        /// </summary>
        public int MarketID { get; set; }
        /// <summary>
        /// Market.
        /// </summary>
    //    public virtual Market Market { get; set; }
        /// <summary>
        /// Instruction input date and time.
        /// </summary>
        public DateTime InstructionDateTime { get; set; }
        /// <summary>
        /// Instruction Status: P = Pending completion, C = Completed, E = Error.
        /// </summary>
        [StringLength(1)]
        public string Status { get; set; }
        /// <summary>
        /// Order Communication Status: S = Sent, E = Error, C = Completed.
        /// </summary>
        [StringLength(1)]
        public string CommStatus { get; set; }

        /// <summary>
        /// MarketOrder ID affected. 
        /// </summary>
        public int MarketOrderID { get; set; }

        ////////////////////////////////////////////////////////////////
        // ADD A NEW PROPERTY WHEN A NEW MARKET IS ADDED
        ////////////////////////////////////////////////////////////////

        public virtual FundsInstruction FundsInstruction { get; set; }

        public DateTime LastUpdate { get; set; }

        [NotMapped]
        public string InstructionFundType { get; set; }

        ////////////////////////////////////////////////////////////////

        //public MarketOrder(Order oOrder)
        //{
        //    this.Order = oOrder;
        //    this.CommStatus = "";
        //    this.LinkOrderID = 0;
        //    this.Market = null;
        //    this.Status = "";
        //}
        public static void Save(MarketInstruction marketInstruction)
        {
            using (var db = new DBContext())
            {
                db.MarketInstructions.Add(marketInstruction);
                db.SaveChanges();
            }
        }
        public static void Update(MarketInstruction marketInstruction)
        {
            using (var db = new DBContext())
            {
                db.Entry(marketInstruction).Property(x => x.Status).IsModified = true;
                db.Entry(marketInstruction).Property(x => x.LastUpdate).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}
