using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class MarketOrder
    {
        /// <summary>
        /// Market order ID.
        /// </summary>
        [Key]
        public int MarketOrderID { get; set; } // One sequence for all system market orders.
        /// <summary>
        /// Client order ID.
        /// </summary>
        public int OrderID { get; set; }
        
        /// <summary>
        /// Client order.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Market identifier.
        /// </summary>
        public int MarketID { get; set; }
        
        /// <summary>
        /// Market.
        /// </summary>
    //    public virtual Market Market { get; set; }
        
        /// <summary>
        /// Order input date and time.
        /// </summary>
        public DateTime OrderDateTime { get; set; }

        /// <summary>
        /// Order Status: P = Pending completion, A = Canceled, C = Completed, E = Error.
        /// </summary>
        [StringLength(1)]
        public string Status { get; set; }
        /// <summary>
        /// Order Communication Status: S = Sent, E = Error, C = Completed.
        /// </summary>
        [StringLength(1)]
        public string CommStatus { get; set; }

        ////////////////////////////////////////////////////////////////
        // ADD A NEW PROPERTY WHEN A NEW MARKET IS ADDED
        ////////////////////////////////////////////////////////////////

        public virtual FundsOrder FundsOrder { get; set; }

        public DateTime LastUpdate { get; set; }

        ////////////////////////////////////////////////////////////////

        //public MarketOrder(Order oOrder)
        //{
        //    this.Order = oOrder;
        //    this.CommStatus = "";
        //    this.LinkOrderID = 0;
        //    this.Market = null;
        //    this.Status = "";
        //}
        public static void Save(MarketOrder marketOrder)
        {
            using (var db = new DBContext())
            {
                db.MarketOrders.Add(marketOrder);
                db.SaveChanges();
            }
        }
        public static void Update(MarketOrder marketOrder)
        {
            using (var db = new DBContext())
            {
                db.Entry(marketOrder).Property(x => x.Status).IsModified = true;
                db.Entry(marketOrder).Property(x => x.LastUpdate).IsModified = true;
                db.SaveChanges();
            }
        }
        public static void UpdateAll(MarketOrder marketOrder)
        {
            using (var db = new DBContext())
            {
                db.MarketOrders.Attach(marketOrder);
                db.Entry(marketOrder).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static MarketOrder Get(int id)
        {
            using (var db = new DBContext())
            {
                return db.MarketOrders.Find(id);
            }
        }
    }
}
