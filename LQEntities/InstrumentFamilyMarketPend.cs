using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace INOM.Entities
{
    public class InstrumentFamilyMarketPend
    {
       
        [Key]
        public int InstrumentFamilyID { get; set; }
        [Key]
        public int MarketID { get; set; }
        public bool Enabled { get; set; }
        public DateTime? VerifiedDateTime { get; set; }

        public static InstrumentFamilyMarketPend Save(InstrumentFamilyMarketPend instrumentMarket)
        {
            using (var db = new DBContext())
            {
                db.InstrumentFamilyMarketsPend.Add(instrumentMarket);
                db.SaveChanges();

                return instrumentMarket;
            }
        }

        /// <summary>
        /// Return list InstrumentFamilyMarketPend x instrumentFamilyID
        /// </summary>
        /// <param name="instrumentFamilyID"></param>
        /// <returns></returns>
        public static List<InstrumentFamilyMarketPend> GetList(int instrumentFamilyID)
        {
            using (var db = new DBContext())
            {
                return (from ins in db.InstrumentFamilyMarketsPend where ins.InstrumentFamilyID == instrumentFamilyID select ins).ToList();
            }
        }
    }
}
