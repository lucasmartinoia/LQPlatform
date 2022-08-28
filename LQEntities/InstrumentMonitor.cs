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
    public class InstrumentMonitor
    {
        [Key]
        public int InstrumentMonitorID { get; set; }
        public int Frequency { get; set; }
        public int Depth { get; set; }
        public virtual Instrument Instrument { get; set; }
        public int InstrumentID { get; set; }

        public static List<InstrumentMonitor> GetList()
        {
            List<InstrumentMonitor> colReturn = null;

            using (var db = new DBContext())
            {
                colReturn = db.InstrumentsMonitor.Include("Instrument").ToList();
            }

            return colReturn;
        }

        public void Save()
        {
            using (var db = new DBContext())
            {
                db.InstrumentsMonitor.Attach(this);
                db.Entry(this).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            using (var db = new DBContext())
            {
                db.InstrumentsMonitor.Attach(this);
                db.InstrumentsMonitor.Remove(this);
                db.SaveChanges();
            }
        }

        public static void UpdateAll()
        {
            // Get instruments for monitor
            List<Instrument> colInstruments = Instrument.GetList();
            List<InstrumentMonitor> colInstrumentMonitor = InstrumentMonitor.GetList();
            List<MonitorSetting> colMonitor = MonitorSetting.GetList();

            foreach (Instrument oInstrument in colInstruments)
            {
                MonitorSetting oMonitor = colMonitor.Where(x => oInstrument.CFICode == x.CFICodes && (x.Segments.Contains(oInstrument.SegmentID) || string.IsNullOrEmpty(x.Segments))).FirstOrDefault();
                InstrumentMonitor oInstrumentMonitor = colInstrumentMonitor.Where(x => x.Instrument.MarketID == oInstrument.MarketID && x.Instrument.Symbol == oInstrument.Symbol).FirstOrDefault();

                if(oMonitor!=null && oInstrumentMonitor==null && oInstrument.Active==true)
                {
                    // Add to monitor
                    oInstrumentMonitor = new InstrumentMonitor();
                    oInstrumentMonitor.InstrumentID = oInstrument.InstrumentID;
                    oInstrumentMonitor.Frequency = 1;
                    oInstrumentMonitor.Depth = 1;
                    oInstrumentMonitor.Save();
                }
                else if(oInstrumentMonitor != null && (oMonitor == null || oInstrument.Active==false))
                {
                    // Remove from monitor
                    colInstrumentMonitor.Remove(oInstrumentMonitor);
                    oInstrumentMonitor.Delete();
                }
            }
        }
    }
}
