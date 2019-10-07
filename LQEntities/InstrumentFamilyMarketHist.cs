using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INOM.Entities
{
    public class InstrumentFamilyMarketHist
    {
       
        [Key]
        public int InstrumentFamilyID { get; set; }
        [Key]
        public int MarketID { get; set; }
        public bool Enabled { get; set; }
        public DateTime VerifiedDateTime { get; set; }

        public static InstrumentFamilyMarketHist Save(InstrumentFamilyMarketHist instrumentMarket)
        {
            using (var db = new DBContext())
            {
                db.InstrumentFamilyMarketsHist.Add(instrumentMarket);
                db.SaveChanges();

                return instrumentMarket;
            }
        }

        /// <summary>
        /// Save list InstrumentFamilyMarketHist
        /// </summary>
        /// <param name="instrumentMarketsHistToSave"></param>
        public static void SaveRange(List<InstrumentFamilyMarketHist> instrumentMarketsHistToSave)
        {
            using (var db = new DBContext())
            {
                db.InstrumentFamilyMarketsHist.AddRange(instrumentMarketsHistToSave);
                db.SaveChanges();
            }
        }
    }
}
