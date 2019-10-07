
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace INOM.Entities
{
    public class InstrumentMae
    {
        [Key]
        public int InstrumentMaeID { get; set; }
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

        public string MaturityDate { get; set; }

        /// <summary>
        /// Save Fund Trade.
        /// </summary>
        public static void Save(InstrumentMae instrumentMae)
        {
            using (var db = new DBContext())
            {
                db.InstrumentsMae.Add(instrumentMae);
                db.SaveChanges();
            }
        }

        public static void SaveMassive(List<InstrumentMae> listInstrumentMae)
        {
            using (var db = new DBContext())
            {
                db.InstrumentsMae.AddRange(listInstrumentMae);
                db.SaveChanges();
            }
        }

        public static void Truncate()
        {
            using (var db = new DBContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE InstrumentsMae");
            }
        }
    }
}
