using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class Strategy
    {
        [Key]
        public int StrategyID { get; set; }
        public string StrategyName { get; set; }
        public bool Active { get; set; }
        public decimal TradeAmountMax { get; set; }
        public double TradeCashPerc { get; set; }
        public int MaxOrdersPerDay { get; set; }
        public double OppSizePerc { get; set; }
        public double OppMinRate1 { get; set; }
        public double OppMinRate2 { get; set; }
        public bool AutoTrade { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public static List<Strategy> GetList(bool bOnlyActive = false)
        {
            List<Strategy> colReturn = null;

            using (var db = new DBContext())
            {
                colReturn = db.Strategies.Where(x => (bOnlyActive == true && x.Active == true || bOnlyActive == false)).ToList();
            }

            return colReturn;
        }
    }
}
