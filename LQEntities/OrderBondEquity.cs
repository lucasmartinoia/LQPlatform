using INOM.Support;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INOM.Entities
{
    public class OrderBondEquity : Order, ICloneable
    {
        /// <summary>
        /// Product code.
        /// </summary>
        [StringLength(50)]
        public string InstrumentID { get; set; }
        
        /// <summary>
        /// Settlement date (Fecha de liquidacion)
        /// </summary>
        public DateTime? SettleDate { get; set; }
        
        /// <summary>
        /// Settle term (Plazo de liquidacion expresado en horas: 0,24,48).
        /// </summary>
        public int? SettleTerm { get; set; }

        /// <summary>
        /// Market ID
        /// </summary>
        public int? MarketID { get; set; }

        /// <summary>
        /// Order expiration date in the market.
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// Order expiration time in the market. Format: "HH:mm", i.e. "16:32".
        /// </summary>
        [StringLength(5)]
        public string ExpireTime { get; set; }

        /// <summary>
        /// True if order is Buy, False for Sell order
        /// </summary>
        public bool? Buy { get; set; }

        /// <summary>
        /// Order Take Profit Price.
        /// </summary>
        public double? TakeProfit { get; set; }

        /// <summary>
        /// Order Stop Loss Price.
        /// </summary>
        public double? StopLoss { get; set; }

        /// <summary>
        /// Market TimeInForce attribute. Possible values:
        /// 0 Day (Default)
        /// 1 Good Till Cancel(GTC)
        /// 2 At the Open(OPG)
        /// 3 Immediate or Cancel(IOC)
        /// 4 Fill or Kill(FOK)
        /// 6 Good Till Date(GTD)
        /// 7 At the Close(ATC)
        /// 9 Good for Auction(GFA)
        /// </summary>
        public int? OrderLife { get; set; }

        /// <summary>
        /// Indica si el cliente esta operando por posición.
        /// </summary>
        public bool? PositionOperation { get; set; }

        /// <summary>
        /// Nombres de los mercados a no considerar (por regla de negocio en el Policy System), separados por el carácter "|".
        /// </summary>
        [StringLength(200)]
        public string ExcludedMarkets { get; set; }

        public static void Save(OrderBondEquity OrderBondEquity)
        {
            using (var db = new DBContext())
            {
                db.OrderBondEquities.Add(OrderBondEquity);
                db.SaveChanges();
            }
        }

        public static void Update(OrderBondEquity OrderBondEquity)
        {
            using (var db = new DBContext())
            {
                db.OrderBondEquities.Attach(OrderBondEquity);
                db.Entry(OrderBondEquity).Property(x => x.Status).IsModified = true;
                db.Entry(OrderBondEquity).Property(x => x.LastUpdate).IsModified = true;
                db.SaveChanges();
            }
        }

        public static List<OrderBondEquity> GetAll()
        {
            using (var db = new DBContext())
            {
                return (from data in db.OrderBondEquities select data).ToList();
            }
        }

        public static bool Validate(OrderBondEquity item)
        {
            bool bReturn = true;

            //TODO

            return bReturn;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public static void UpdateAll(OrderBondEquity orderBondEquity)
        {
            throw new NotImplementedException();
        }
    }
}
