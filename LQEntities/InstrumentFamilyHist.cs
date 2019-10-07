using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace INOM.Entities
{
    public class InstrumentFamilyHist
    {

        [Key]
        public int InstrumentFamilyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? MandatoryMarketID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string MandatoryMarket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? SuggestedMarketID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string SuggestedMarket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool SettlementTermCash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool SettlementTerm24hs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool SettlementTerm48hs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool SettlementTerm72hs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool SettlementTerm96hs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool SettlementTerm120hs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SetupDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(10)]
        public string SetupUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ModifiedDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(10)]
        public string ModifiedUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime VerifiedDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(10)]
        public string VerifiedUser { get; set; }

        public static List<InstrumentFamilyHist> GetList()
        {
            using (var db = new DBContext())
            {
                return (from ins in db.InstrumentFamiliesHist select ins).ToList();
            }
        }


        public static InstrumentFamilyHist Get(int instrumentFamilyID)
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstrumentFamiliesHist
                        where data.InstrumentFamilyID.Equals(instrumentFamilyID)
                        select data).FirstOrDefault();
            }
        }

        /// <summary>
        /// Save one InstrumentFamilyHist
        /// </summary>
        /// <param name="instrumentPend"></param>
        /// <returns></returns>
        public static InstrumentFamilyHist Save(InstrumentFamilyHist instrumentPend)
        {
            using (var db = new DBContext())
            {
                db.InstrumentFamiliesHist.Add(instrumentPend);
                db.SaveChanges();

                return instrumentPend;
            }
        }

        /// <summary>
        /// Save safe transaction InstrumentFamily and InstrumentFamilyMarket.
        /// (Relationship between both)
        /// </summary>
        /// <param name="instrumentFamilyHist"></param>
        /// <param name="instrumentFamilyMarketHist"></param>
        /// <returns></returns>
        public static InstrumentFamilyHist Save(InstrumentFamilyHist instrumentFamilyHist, List<InstrumentFamilyMarketHist> instrumentFamilyMarketsHist)
        {
            using (var context = new DBContext().Database.BeginTransaction())
            {
                try
                {
                    using (var db = new DBContext())
                    {
                        db.InstrumentFamiliesHist.Add(instrumentFamilyHist);
                        db.InstrumentFamilyMarketsHist.AddRange(instrumentFamilyMarketsHist);
                        
                        db.SaveChanges();
                    }

                    context.Commit();
                }
                catch (Exception ex)
                {
                    context.Rollback();

                    throw ex;
                }
            }
            return instrumentFamilyHist;
        }
    }
}
