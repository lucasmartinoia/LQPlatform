using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class Opportunity
    {
        [Key]
        public int OpportunityID { get; set; }
        public virtual Strategy Strategy { get; set; }
        public int StrategyID { get; set; }
        public DateTime DateTime { get; set; }
        public double ProfitRate { get; set; }
        public decimal AmountMin { get; set; }
        public decimal AmountMax { get; set; }
        public string MarketID { get; set; }
        public string Symbol1 { get; set; }
        public string Symbol2 { get; set; }
        public double BuyPrice1 { get; set; }
        public double SellPrice2 { get; set; }
        public string Currency { get; set; }

        public void Save()
        {
            using (var db = new DBContext())
            {
                db.Opportunities.Attach(this);
                db.SaveChanges();
            }
        }
    }
}
