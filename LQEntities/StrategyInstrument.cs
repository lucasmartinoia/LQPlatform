using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class StrategyInstrument
    {
        [Key]
        public int StrategyInstrumentID { get; set; }
        public int StrategyID { get; set; }
        public int InstrumentID { get; set; }
        public int Order { get; set; }
        public virtual Instrument Instrument { get; set; }
    }
}
