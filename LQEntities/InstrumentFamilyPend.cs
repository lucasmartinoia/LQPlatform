using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace INOM.Entities
{
    public class InstrumentFamilyPend
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
        public DateTime? VerifiedDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(10)]
        public string VerifiedUser { get; set; }

        public static List<InstrumentFamilyPend> GetList()
        {
            using (var db = new DBContext())
            {
                return (from ins in db.InstrumentFamiliesPend select ins).ToList();
            }
        }


        /// <summary>
        /// Return InstrumentFamilyPend x instrumentFamilyID
        /// </summary>
        /// <param name="instrumentFamilyID"></param>
        /// <returns></returns>
        public static InstrumentFamilyPend Get(int instrumentFamilyID)
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstrumentFamiliesPend
                        where data.InstrumentFamilyID.Equals(instrumentFamilyID)
                        select data).FirstOrDefault();
            }
        }

        public static InstrumentFamilyPend Save(InstrumentFamilyPend instrumentPend)
        {
            using (var db = new DBContext())
            {
                db.InstrumentFamiliesPend.Add(instrumentPend);
                db.SaveChanges();

                return instrumentPend;
            }
        }

        /// <summary>
        /// Save safe transaction InstrumentFamily and InstrumentFamilyMarket.
        /// Pending (Relationship between both)
        /// </summary>
        /// <param name="instrumentPend"></param>
        /// <param name="instrumentMarket"></param>
        /// <returns></returns>
        public static InstrumentFamilyPend Save(InstrumentFamilyPend instrumentPend, List<InstrumentFamilyMarketPend> instrumentMarkets)
        {
            using (var context = new DBContext().Database.BeginTransaction())
            {
                try
                {
                    using (var db = new DBContext())
                    {
                        db.InstrumentFamiliesPend.Add(instrumentPend);
                        db.InstrumentFamilyMarketsPend.AddRange(instrumentMarkets);
                        
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
            return instrumentPend;
        }

        internal static InstrumentFamilyPend Delete(InstrumentFamilyPend instrumentFamilyPendToDelete, List<InstrumentFamilyMarketPend> instrumentMarketsPendToDelete)
        {
            using (var context = new DBContext().Database.BeginTransaction())
            {
                try
                {
                    using (var db = new DBContext())
                    {
                        db.InstrumentFamilyMarketsPend.RemoveRange(instrumentMarketsPendToDelete);
                        db.SaveChanges();

                        db.InstrumentFamiliesPend.Remove(instrumentFamilyPendToDelete);
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

            return instrumentFamilyPendToDelete;
        }
    }
}
