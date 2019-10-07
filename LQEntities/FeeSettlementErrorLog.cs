using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class FeeSettlementErrorLog
    {
        /// <summary>
        /// FeeSettlementErrorLog ID.
        /// </summary>
        [Key]
        public int ErrorLogID { get; set; }
        /// <summary>
        /// FeeSettlement ID.
        /// </summary>
        public int FeeSettlementID { get; set; }
        /// <summary>
        /// Error Message.
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// StackTrace of error.
        /// </summary>
        public string StackTrace { get; set; } 
        /// <summary>
        /// Error moment 
        /// </summary>
        public DateTime When { get; set; }

        public static void Save(FeeSettlementErrorLog feeSettlementErrorLog)
        {
            using (var db = new DBContext())
            {
                db.FeeSettlementErrorLog.Add(feeSettlementErrorLog);
                db.SaveChanges();
            }
        }
    }
}
