
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace INOM.Entities
{
    public class InstrumentByma
    {
        [Key]
        public int InstrumentBymaID { get; set; }
        public string Symbol { get; set; }
        public string SecurityID { get; set; }
        public string SettlmntTyp { get; set; }
        
        public string SecurityAltID { get; set; }
        public string SecurityAltIDSource { get; set; }
        public string CFICode { get; set; }
        public string SecurityType { get; set; }
        public string SecurityStat { get; set; }
        public string TradingSessionID { get; set; }
        public string OrderType { get; set; }
        public string TimeInForce { get; set; }
        public string SecurityExchange { get; set; }
        public string Currency { get; set; }

        /// <summary>
        /// Save Fund Trade.
        /// </summary>
        public static void Save(InstrumentByma instrumentByma)
        {
            using (var db = new DBContext())
            {
                db.InstrumentsByma.Add(instrumentByma);
                db.SaveChanges();
            }
        }

        public static void SaveMassive(List<InstrumentByma> listInstrumentByma)
        {
            using (var db = new DBContext())
            {
                db.InstrumentsByma.AddRange(listInstrumentByma);
                db.SaveChanges();
            }
        }

        public static void Truncate()
        {
            using (var db = new DBContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE InstrumentsByma");
            }
        }
    }
}
