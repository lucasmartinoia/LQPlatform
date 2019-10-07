using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace INOM.Entities
{
    public enum EnumMarkets
    {
        FUNDS = 1,
        BYMA = 2,
        MAE = 3
    }
    public class Market
    {
        /// <summary>
        /// Market identifier.
        /// </summary>
        [Key]
        public int MarketID { get; set; }
        /// <summary>
        /// Market name (i.e. BYMA, MAE, ROFEX).
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Market description (i.e. "BYMA es una nueva Bolsa de Valores que integra y representa a los principales actores del mercado de valores del país.").
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        /// <summary>
        /// Handle market availability.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(200)]
        public string RejectReason { get; set; }
        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime SetupDateTime { get; set; }
        /// <summary>
        /// User of creation
        /// </summary>
        [StringLength(10)]
        public string SetupUser { get; set; }

        /// <summary>
        /// Products available in the market.
        /// </summary>
        public virtual List<MarketProduct> Products { get; set; }
        /// <summary>
        /// Modification date and time.
        /// </summary>
        public DateTime ModifiedDateTime { get; set; }
        /// <summary>
        ///User of modification
        /// </summary>
        [StringLength(10)]
        public string ModifiedUser { get; set; }
        /// <summary>
        /// Verifigin date and time.
        /// </summary>
        public DateTime VerifiedDateTime { get; set; }

        /// <summary>
        /// Verifiying user 
        /// </summary>
        [StringLength(10)]
        public string VerifiedUser { get; set; }

        /// <summary>
        /// Depositante para la liquidación
        /// </summary>
        [StringLength(10)]
        public string Depositor { get; set; }


        /// <summary>
        /// Comitente para la liquidación
        /// </summary>
        [StringLength(10)]
        public string Custody { get; set; }
        /// <summary>
        /// Opening hours
        /// </summary>
        [StringLength(5)]
        public string MarketStartTime { get; set; }

        /// <summary>
        /// Closing hours
        /// </summary>
        [StringLength(5)]
        public string MarketEndTime { get; set; }

        /// <summary>
        /// Indica si es Cartera Propia
        /// </summary>
        public bool OwnPortfolio { get; set; }

        /// <summary>
        /// Indica si la operatoria es manual o automática
        /// </summary>
        public bool ManualOperation { get; set; }

        /// <summary>
        /// Pending authorization: true | false
        /// </summary>
        public bool Delete { get; set; }


        /// <summary>
        /// Get list of market x pending authirizacion
        /// pendingAutorization = true: ALL market 
        /// </summary>
        /// <param name="pendingAutorization"></param>
        /// <returns></returns>
        public static List<Market> GetList()
        {
            using (var db = new DBContext())
            {
                return (from data in db.Markets select data).ToList();
            }
        }

        /// <summary>
        /// Return Market x MarketID
        /// </summary>
        /// <param name="idMarket"></param>
        /// <returns></returns>
        public static Market Get(int idMarket)
        {
            using (var db = new DBContext())
            {
                return (from data in db.Markets
                        where data.MarketID.Equals(idMarket)
                        select data).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marketID"></param>
        /// <returns></returns>
        public static Market Save(Market market)
        {
            using (var db = new DBContext())
            {
                db.Markets.Add(market);
                db.SaveChanges();

                return market;
            }
        }

        public static Market Update(Market marketMapper)
        {
            using (var db = new DBContext())
            {
                db.Markets.Attach(marketMapper);
                db.Entry(marketMapper).State = EntityState.Modified;
                db.SaveChanges();

                return marketMapper;
            }
        }

        public static Market DeleteMarket(Market market)
        {
            using (var db = new DBContext())
            {
                db.Markets.Attach(market);
                db.Entry(market).State = EntityState.Deleted;
                db.SaveChanges();

                return market;
            }
        }
    }
}
