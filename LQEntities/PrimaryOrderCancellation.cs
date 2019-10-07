using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace INOM.Entities
{
    /// <summary>
    /// The BymaOrderCancellation message is used by an entity to send 
    /// orders in an electronic manner to the market trading system.
    /// </summary>
    public class BymaOrderCancellation
    {
        public BymaOrderCancellation() { }

        public BymaOrderCancellation(int orderID)
        {
            BymaOrder bymaOrder = Retrieve.GetBymaOrderFromID(orderID);
            OrigCIOrdID = bymaOrder.ClOrdID;
            BymaOrderID = orderID;
            ClOrdID = "BGBAC" + OrigCIOrdID.Substring(5, 13);
            Currency = bymaOrder.Currency;
            Side = bymaOrder.Side;
            Symbol = bymaOrder.Symbol;
        }

        /// <summary>
        /// ByMA order ID.
        /// </summary>
        [Key]
        public int BymaOrderCancellationID { get; set; }
        
        public int BymaOrderID { get; set; }
        /// <summary>
        /// Client specified identifier of the order.
        /// </summary>
        [StringLength(19)]
        public string ClOrdID { get; set; }

        /// <summary>
        /// Client specified identifier of the order.
        /// </summary>
        [StringLength(19)]
        public string OrigCIOrdID { get; set; }

        /// <summary>
        /// Indentifies currency used for price
        /// </summary>
        public string Currency { get; set; }

       
        /// <summary>
        /// Side of the order.
        /// 1 Buy
        /// 2 Sell
        /// 5 Sell Short
        /// </summary>
        public string Side { get; set; }

        /// <summary>
        /// Identifier of the instrument.
        /// </summary>
        public string Symbol { get; set; }

        public static async Task Insert(BymaOrderCancellation bymaOrderCancellation)
        {
            using (var db = new DBContext())
            {
                db.BymaOrderCancellations.Add(bymaOrderCancellation);
                db.SaveChanges();
            }
        }
    }
}
