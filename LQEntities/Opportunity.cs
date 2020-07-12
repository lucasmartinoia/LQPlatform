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
        public long Timestamp1 { get; set; }
        public long Timestamp2 { get; set; }

        public double Size1 { get; set; }
        public double Size2 { get; set; }

        public string Currency { get; set; }
        // Indicates if strategy required a price / size validation to the market.
        public bool Checked { get; set; }
        // Result of the check process.
        public bool CheckPassed { get; set; }
        // Check error description.
        public string CheckError { get; set; }


        public void Save()
        {
            using (var db = new DBContext())
            {
                db.Opportunities.Attach(this);
                db.Entry(this).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
