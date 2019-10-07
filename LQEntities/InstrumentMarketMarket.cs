using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INOM.Entities
{
    public class InstrumentMarketMarket
    {
        
        [Key]
        public int InstrumentID { get; set; }

        [Key]
        public int MarketID { get; set; }

        public bool Enabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime VerifiedDateTime { get; set; }

        /// <summary>
        /// Return list InstrumentFamilyMarket x InstrumentFamilyID
        /// </summary>
        /// <param name="InstrumentID"></param>
        /// <returns></returns>
        public static List<InstrumentMarketMarket> GetList(int instrumentID)
        {
            using (var db = new DBContext())
            {
                return (from ins in db.InstrumentMarketMarkets where ins.InstrumentID == instrumentID select ins).ToList();
            }
        }
    }
}
