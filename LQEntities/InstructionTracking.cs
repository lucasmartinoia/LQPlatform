using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class InstructionTracking
    {
        /// <summary>
        /// Instruction Tracking ID.
        /// </summary>
        [Key]
        public int InstructionTrackingID { get; set; }

        /// <summary>
        /// Instruction Identifier.
        /// </summary>
        [Required]
        public int InstructionID { get; set; }

        /// <summary>
        /// Instruction.
        /// </summary>
        public virtual Instruction Instruction { get; set; }

        /// <summary>
        /// Market Instruction Identifier.
        /// </summary>
        public int MarketInstructionID { get; set; }

        /// <summary>
        /// Market Trade Identifier.
        /// </summary>
        public int MarketTradeID { get; set; }

        /// <summary>
        /// Event description.
        /// </summary>
        [StringLength(200)]
        public string Event { get; set; }

        /// <summary>
        /// Event description.
        /// </summary>
        [StringLength(200)]
        public string EventInfo { get; set; }

        /// <summary>
        /// Component name.
        /// </summary>
        [StringLength(200)]
        public string Component { get; set; }

        /// <summary>
        /// Record creation date and time.
        /// </summary>
        public DateTime When { get; set; }

        public static void Save(InstructionTracking oTracking)
        {
            using (var db = new DBContext())
            {
                db.InstructionsTracking.Add(oTracking);
                db.SaveChanges();
            }
        }
    }
}
