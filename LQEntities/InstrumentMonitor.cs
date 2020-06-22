using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class InstrumentMonitor
    {
        [Key]
        public int InstrumentID { get; set; }
        public int Frequency { get; set; }
        public int Depth { get; set; }
        public virtual Instrument Instrument { get; set; }

        public static List<InstrumentMonitor> GetList()
        {
            List<InstrumentMonitor> colReturn = null;

            using (var db = new DBContext())
            {
                colReturn = db.InstrumentsMonitor.Include("Instrument").ToList();
            }

            return colReturn;
        }
    }
}
