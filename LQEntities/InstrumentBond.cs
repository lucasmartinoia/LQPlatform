using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace INOM.Entities
{
    public class InstrumentBond : Instrument, ICloneable
    {

        /// <summary>
        /// Date format string($date-time)
        ///   example: 26/06/2018
        /// </summary>
        public string IssuedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string RateIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string MaturityDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FaceValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string CouponFrequence { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? RateIndexSpread { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinPurchaseAmt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string RedemCurrency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string CouponCurrency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? RedemPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Daycount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string NotionalIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Amortization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PaymentLag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? FixRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cap { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Floor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(10)]
        public string FlipperDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string FlipFrequency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Capitaliza { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string TipoGarantia { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string GovernmentBondTypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string TipoEstructura { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? ValorResidual { get; set; }

        //Virtuales
        //public CouponsSchedules CouponsSchedules { get; set; }
        //public PiksSchedules PiksSchedules { get; set; }
        //public SinkingSchedules SinkingSchedules { get; set; }
        //public PutCalls PutCalls { get; set; }


        /// <summary>
        /// Save bond
        /// </summary>
        /// <param name="b"></param>
        public static void Save(InstrumentBond b)
        {
            using (var db = new DBContext())
            {
                db.InstrumentBonds.Add(b);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Update bond
        /// </summary>
        /// <param name="instrumentBond"></param>
        public static void Update(InstrumentBond instrumentBond)
        {
            using (var db = new DBContext())
            {
                db.InstrumentBonds.Attach(instrumentBond);
                db.Entry(instrumentBond).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Delete all bond
        /// </summary>
        public static void DeleteAll()
        {
            using (var db = new DBContext())
            {
                var allRec = db.InstrumentBonds;
                db.InstrumentBonds.RemoveRange(allRec);
                db.SaveChanges();
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
