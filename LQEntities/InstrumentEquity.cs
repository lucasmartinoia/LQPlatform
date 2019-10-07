using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INOM.Entities
{
    public class InstrumentEquity : Instrument, ICloneable
    {
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Underlying { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public decimal? TradingSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? AdrNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? UnderlyingNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string LiderMerval { get; set; }

        /// <summary>
        /// Save Equity
        /// </summary>
        /// <param name="b"></param>
        public static void Save(InstrumentEquity equity)
        {
            using (var db = new DBContext())
            {
                db.InstrumentEquities.Add(equity);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Update Equity
        /// </summary>
        /// <param name="instrumentEquity"></param>
        public static void Update(InstrumentEquity instrumentEquity)
        {
            using (var db = new DBContext())
            {
                db.InstrumentEquities.Attach(instrumentEquity);
                db.Entry(instrumentEquity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Delete all Equity
        /// </summary>
        public static void DeleteAll()
        {
            using (var db = new DBContext())
            {
                var allRec = db.InstrumentEquities;
                db.InstrumentEquities.RemoveRange(allRec);
                db.SaveChanges();
            }
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
