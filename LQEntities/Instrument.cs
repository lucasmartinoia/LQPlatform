using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LatamQuants.Entities
{
    public class Instrument
    {
        [Key]
        public int InstrumentID { get; set; }
        public string Symbol { get; set; }
        public string MarketID { get; set; }
        public string SegmentID { get; set; }
        public double LowLimitPrice { get; set; }
        public double HighLimitPrice { get; set; }
        public double MinPriceIncrement { get; set; }
        public double MinTradeVol { get; set; }
        public double MaxTradeVol { get; set; }
        public double TickSize { get; set; }
        public double ContractMultiplier { get; set; }
        public double RoundLot { get; set; }
        public double PriceConvertionFactor { get; set; }
        public DateTime? MaturityDate { get; set; }
        public string Currency { get; set; }
        public string OrderTypes { get; set; }
        public string TimesInForce { get; set; }
        public string SecurityType { get; set; }
        public string SettlementType { get; set; }
        public int InstrumentPricePrecision { get; set; }
        public int InstrumentSizePrecision { get; set; }
        public string CFICode { get; set; }
        public bool Active { get; set; }
        public DateTime SetupDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public static List<Instrument> GetList(bool bOnlyActive=false)
        {
            List<Instrument> colReturn = null;

            using (var db = new DBContext())
            {
                colReturn = db.Instruments.Where(x=>(bOnlyActive == true && x.Active==true || bOnlyActive==false)).ToList();
            }

            return colReturn;
        }

        public static Instrument GetBySymbol(string pSymbol)
        {
            Instrument oReturn = null;

            using (var db = new DBContext())
            {
                oReturn = db.Instruments.Where(x => x.Symbol==pSymbol).FirstOrDefault();
            }

            return oReturn;
        }

        public void Update()
        {
            using (var db = new DBContext())
            {
                db.Instruments.Attach(this);
                db.Entry(this).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void SaveList(List<Instrument> pcolInstruments)
        {
            using (var db = new DBContext())
            {
                List<Instrument> colInstruments = db.Instruments.ToList();

                // Add new instruments
                foreach(Instrument pInstrument in pcolInstruments)
                {
                    // New instrument
                    Instrument oDbInstrument = colInstruments.Find(x => x.MarketID == pInstrument.MarketID && x.Symbol == pInstrument.Symbol);

                    if (oDbInstrument == null && 
                        (pInstrument.MaturityDate == null || 
                            (pInstrument.MaturityDate != null && pInstrument.MaturityDate >= DateTime.Now.Date)))
                    {
                        pInstrument.Active = true;
                        pInstrument.SetupDate = DateTime.Now;
                        pInstrument.LastUpdate = pInstrument.SetupDate;
                        db.Instruments.Add(pInstrument);
                    }
                    else if(pInstrument.MaturityDate != null && pInstrument.MaturityDate >= DateTime.Now.Date)// Update maturity date instrument
                    {
                        oDbInstrument.Active = true;
                        oDbInstrument.LastUpdate = DateTime.Now;
                        oDbInstrument.MaturityDate = pInstrument.MaturityDate;
                    }
                    else
                    {
                        // Instrument with invalid Maturity Date is discarded.
                    }
                }

                db.SaveChanges();

                // Desactive all instrument which have not were received from market or maturity date has ended.
                List<Instrument> colDBInstruments = db.Instruments.ToList();

                foreach(Instrument oDbInstrument in colDBInstruments)
                {
                    bool bActive = true;

                    // Check maturity date.
                    if (oDbInstrument.MaturityDate!=null && oDbInstrument.MaturityDate.Value.Date < DateTime.Now.Date)
                    {
                        bActive = false;
                    }
                    else // Check if is not active in the market.
                    {
                        Instrument pInstrument = pcolInstruments.Find(x => x.MarketID == oDbInstrument.MarketID && x.Symbol == oDbInstrument.Symbol);

                        if (pInstrument == null)
                        {
                            bActive = false;
                        }
                    }

                    if(bActive==false)
                    {
                        oDbInstrument.Active = false;
                        oDbInstrument.LastUpdate = DateTime.Now;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
