using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace INOM.Entities
{
    public class InstrumentFamily
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


        public static List<InstrumentFamily> GetList()
        {
            using (var db = new DBContext())
            {
                return (from ins in db.InstrumentFamilies select ins).ToList();
            }
        }

        /// <summary>
        /// Return list InstrumentFamily x instrumentFamilyID
        /// </summary>
        /// <param name="instrumentFamilyID"></param>
        /// <returns></returns>
        public static InstrumentFamily Get(int instrumentFamilyID)
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstrumentFamilies
                        where data.InstrumentFamilyID.Equals(instrumentFamilyID)
                        select data).FirstOrDefault();
            }
        }

        public static InstrumentFamily Save(InstrumentFamily instrumentMapper)
        {
            return instrumentMapper;
        }

        public static InstrumentFamily Update(InstrumentFamily instrumentMapper)
        {
            return instrumentMapper;
        }

        public static InstrumentFamily Verify(InstrumentFamily instrumentMapper)
        {
            return instrumentMapper;
        }

        public static InstrumentFamily Delete(InstrumentFamily instrumentMapper)
        {
            return instrumentMapper;
        }

        public static InstrumentFamily Delete(InstrumentFamily instrumentFamilyToDelete, List<InstrumentFamilyMarket> instrumentMarketsToDelete)
        {

            using (var context = new DBContext().Database.BeginTransaction())
            {
                try
                {
                    using (var db = new DBContext())
                    {
                        db.InstrumentFamilies.Remove(instrumentFamilyToDelete);
                        db.InstrumentFamilyMarkets.RemoveRange(instrumentMarketsToDelete);

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

            return instrumentFamilyToDelete;
        }

        internal static InstrumentFamily Save(InstrumentFamily instrumentFamilyNewToSave, List<InstrumentFamilyMarket> instrumentMarketsNewToSave)
        {
            using (var context = new DBContext().Database.BeginTransaction())
            {
                try
                {
                    using (var db = new DBContext())
                    {
                        db.InstrumentFamilies.Add(instrumentFamilyNewToSave);
                        db.InstrumentFamilyMarkets.AddRange(instrumentMarketsNewToSave);

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
            return instrumentFamilyNewToSave;
        }
    }
}
