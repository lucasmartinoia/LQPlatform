using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class InstrumentOption
    {
        [Key]
        public int InstrumentOptionID { get; set; }
        public string InstrumentSymbol { get; set; }
        public string OptionSymbol { get; set; }

        public static List<InstrumentOption> GetList()
        {
            List<InstrumentOption> colReturn = null;

            using (var db = new DBContext())
            {
                colReturn = db.InstrumentOptions.ToList();
            }

            return colReturn;
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
