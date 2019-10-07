using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INOM.Entities
{
    public class InstrumentMarketPend
    {
        [Key]
        public int InstrumentID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string CVDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeCV { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeEuroclear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeIsin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeDtc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeMae { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeRic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ProductCodeTicker { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SetupDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string SetupUser { get; set; }

        public DateTime ModifiedDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string ModifiedUser { get; set; }
        public DateTime? VerifiedDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string VerifiedUser { get; set; }
        public static List<InstrumentMarketPend> GetList()
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstrumentMarketsPend select data).ToList();
            }
        }

        /// <summary>
        /// Save safe transaction InstrumentFamily and InstrumentFamilyMarket.
        /// Pending (Relationship between both)
        /// </summary>
        /// <param name="instrumentPend"></param>
        /// <param name="instrumentMarket"></param>
        /// <returns></returns>
        public static InstrumentMarketPend Save(InstrumentMarketPend instrumentPend, List<InstrumentMarketMarketPend> instrumentMarkets)
        {
            using (var context = new DBContext().Database.BeginTransaction())
            {
                try
                {
                    using (var db = new DBContext())
                    {
                        db.InstrumentMarketsPend.Add(instrumentPend);
                        db.SaveChanges();

                        db.InstrumentMarketMarketsPend.AddRange(instrumentMarkets);
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

        /// Return list InstrumentFamily x instrumentFamilyID
        /// </summary>
        /// <param name="instrumentFamilyID"></param>
        /// <returns></returns>
        public static InstrumentMarketPend Get(int instrumentID)
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstrumentMarketsPend
                        where data.InstrumentID.Equals(instrumentID)
                        select data).FirstOrDefault();
            }
        }

        internal static InstrumentMarketPend Delete(InstrumentMarketPend instrumentPend, List<InstrumentMarketMarketPend> insMarketPend)
        {
            using (var context = new DBContext().Database.BeginTransaction())
            {
                try
                {
                    using (var db = new DBContext())
                    {
                        db.InstrumentMarketMarketsPend.RemoveRange(insMarketPend);
                        db.SaveChanges();

                        db.InstrumentMarketsPend.Remove(instrumentPend);
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
    }
}
