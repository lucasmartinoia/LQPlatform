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
        public bool Simulation { get; set; }
        public bool CheckOpportunity { get; set; }
        public bool CheckEntries { get; set; }

        [NotMapped]
        public int OrdersOfDay { get; set; }

        // Private properties
        [NotMapped]
        private DateTime _startTime;
        [NotMapped]
        private DateTime _endTime;

        public static List<Strategy> GetList(bool bOnlyActive = false)
        {
            List<Strategy> colReturn = null;

            using (var db = new DBContext())
            {
                colReturn = db.Strategies.Where(x => (bOnlyActive == true && x.Active == true || bOnlyActive == false)).ToList();
            }

            foreach(Strategy oStrategy in colReturn)
            {
                oStrategy.Initialize();
            }

            return colReturn;
        }

        private void Initialize()
        {
            _startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(this.StartTime.Substring(0, 2)), int.Parse(this.StartTime.Substring(3, 2)), 0);
            _endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(this.EndTime.Substring(0, 2)), int.Parse(this.EndTime.Substring(3, 2)), 0);

            // Get opportunities of the day.
            List<AcceptedOpportunity> colOrders = AcceptedOpportunity.GetList(this.StrategyID, DateTime.Now.Date, "Thanks");
            this.OrdersOfDay = colOrders.Count();
        }

        /// <summary>
        /// Check if the strategy is available to be executed.
        /// </summary>
        /// <returns></returns>
        public bool Executable()
        {
            bool bReturn = this.AutoTrade;

            // Check quantity of max orders at day
            if (bReturn == true && this.OrdersOfDay < this.MaxOrdersPerDay)
            {
                bReturn = InTime();
            }

            return bReturn;
        }

        public bool InTime()
        {
            bool bReturn = (DateTime.Now >= _startTime && DateTime.Now <= _endTime);

            return bReturn;
        }

        /// <summary>
        /// Calculate available amount for this strategy.
        /// </summary>
        /// <param name="pCashAvailable"></param>
        /// <returns></returns>
        public double GetAmountAvailable(double pCashAvailable)
        {
            double oReturn = 0;

            if(this.TradeAmountMax>0)
            {
                oReturn = (double)this.TradeAmountMax;
            }
            else if(this.TradeCashPerc>0)
            {
                oReturn = pCashAvailable * this.TradeCashPerc / 100;
            }
            return oReturn;
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public void Update()
        {
            using (var db = new DBContext())
            {
                db.Strategies.Attach(this);
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            this.Initialize();
        }
    }
}
