using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INOM.Entities
{
    public class InstrumentFamilyMarket
    {
         
        
        [Key]
        public int InstrumentFamilyID { get; set; }

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
        /// <param name="instrumentFamilyID"></param>
        /// <returns></returns>
        public static List<InstrumentFamilyMarket> GetList(int instrumentFamilyID)
        {
            using (var db = new DBContext())
            {
                return (from ins in db.InstrumentFamilyMarkets where ins.InstrumentFamilyID == instrumentFamilyID select ins).ToList();
            }
        }
    }
}
