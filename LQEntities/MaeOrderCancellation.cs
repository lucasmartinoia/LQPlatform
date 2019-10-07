using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace INOM.Entities
{
    /// <summary>
    /// The MaeOrderCancellation message is used by an entity to send 
    /// orders in an electronic manner to the market trading system.
    /// </summary>
    public class MaeOrderCancellation
    {
        public MaeOrderCancellation() { }

        public MaeOrderCancellation(int orderID)
        {
            MaeOrder MaeOrder = Retrieve.GetMaeOrderFromID(orderID);
            OrigCIOrdID = MaeOrder.ClOrdID;
            MaeOrderID = orderID;
            ClOrdID = "BGBAC" + OrigCIOrdID.Substring(5, 13);
            Currency = MaeOrder.Currency;
            Side = MaeOrder.Side;
            Symbol = MaeOrder.Symbol;
        }

        /// <summary>
        /// Mae order ID.
        /// </summary>
        [Key]
        public int MaeOrderCancellationID { get; set; }
        
        public int MaeOrderID { get; set; }
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

        public static async Task Insert(MaeOrderCancellation MaeOrderCancellation)
        {
            using (var db = new DBContext())
            {
                db.MaeOrderCancellations.Add(MaeOrderCancellation);
                db.SaveChanges();
            }
        }
    }
}
