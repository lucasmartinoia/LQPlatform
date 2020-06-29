using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int OrderID1{ get; set; }

        public int OrderID2 { get; set; }

        /// <summary>
        /// To reverse first order.
        /// </summary>
        public int OrderID3 { get; set; }

        /// <summary>
        /// True = order input by robot; False = order input by me.
        /// </summary>
        public bool AutoTrade { get; set; }

        public decimal CashReserved { get; set; }

        public void Save()
        {
            using (var db = new DBContext())
            {
                db.AcceptedOpportunities.Attach(this);
                db.Entry(this).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}
