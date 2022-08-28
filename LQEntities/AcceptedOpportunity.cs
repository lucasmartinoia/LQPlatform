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
    public class AcceptedOpportunity
    {
        [Key]
        public int AcceptedOpportunityID { get; set; }
        public DateTime AcceptedDateTime { get; set; }
        public int OpportunityID { get; set; }
        public virtual Opportunity Opportunity { get; set; }

        /// <summary>
        /// Accepted / In Progress / Thanks / Error / Canceled
        /// </summary>
        public string Status { get; set; } 

        public string OrderID1{ get; set; }

        public string OrderID2 { get; set; }

        /// <summary>
        /// To reverse first order.
        /// </summary>
        public string OrderID3 { get; set; }

        /// <summary>
        /// True = order input by robot; False = order input by me.
        /// </summary>
        public bool AutoTrade { get; set; }

        public decimal CashReserved { get; set; }

        public DateTime LastUpdate { get; set; }

        public string ErrorDescription { get; set; }
        public bool Simulation { get; set; }

        // Indicates if price/size were validated just before send each order.
        public bool EntriesChecked { get; set; }

        public void Save()
        {
            using (var db = new DBContext())
            {
                db.AcceptedOpportunities.Attach(this);
                db.Entry(this).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public static List<AcceptedOpportunity> GetList(int pStrategyID=0, DateTime? pDateTime = null, string pStatus = "",int pLastID=0)
        {
            List<AcceptedOpportunity> colReturn=null;

            using (var db = new DBContext())
            {
                colReturn=db.AcceptedOpportunities.Include("Opportunity").
                    Where(x => (pStrategyID == 0 || x.Opportunity.StrategyID == pStrategyID) && 
                        (pDateTime == null || x.AcceptedDateTime >= pDateTime) && 
                        (pStatus == "" || pStatus == x.Status) && (pLastID==0 || (pLastID>0 && x.AcceptedOpportunityID>pLastID)))
                    .OrderByDescending(x=>x.AcceptedOpportunityID).ToList();
            }

            return colReturn;
        }

        public void Update()
        {
            using (var db = new DBContext())
            {
                db.AcceptedOpportunities.Attach(this);
                db.Entry(this).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
