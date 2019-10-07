using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    /// <summary>
    /// The NewOrderSingle message is used by an entity to send 
    /// orders in an electronic manner to the market trading system.
    /// </summary>
    public class MarketTrade
    {
        /// <summary>
        /// ByMA order ID.
        /// </summary>
        [Key]
        public int MarketTradeID { get; set; }
        public string MarketTickerNo { get; set; }
        public DateTime ExecutionDateTime { get; set; }
        public decimal? Shares { get; set; }
        public double? Price { get; set; }
        /// <summary>
        /// Indentifies currency used for price
        /// </summary>
        public string Currency { get; set; }
        public DateTime SettleDate { get; set; }
        public decimal Amount { get; set; }
        public string MarketSymbol { get; set; }
        public DateTime MaturityDate { get; set; }
        public string CustodyAccountNo { get; set; }
        public decimal AccruedInterestAmt { get; set; }
        public decimal NetMoney { get; set; }
        public int MarketOrderID { get; set; }
        [StringLength(1)]
        public string Status { get; set; }
        public string LastTradeReportID { get; set; }
        public DateTime LastUpdated { get; set; }


        public static void Save(MarketTrade bymaTrade)
        {
            using (var db = new DBContext())
            {
                db.MarketTrades.Add(bymaTrade);
                db.SaveChanges();
            }
        }

        public static void Update(MarketTrade bymaTrade)
        {
            using (var db = new DBContext())
            {
                db.MarketTrades.Update(bymaTrade);
                db.Entry(bymaTrade).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static MarketTrade Get(int marketOrderID)
        {
            using (var db = new DBContext())
            {
                return db.MarketTrades.Find(marketOrderID);
            }
        }
    }
}
