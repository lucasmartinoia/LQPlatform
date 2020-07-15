using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatamQuants.Entities;

namespace LQTrader.ModelViews
{
    public class ViewOpportunity
    {
        public int OpportunityID { get; set; }
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
        public bool Checked { get; set; }
        public bool CheckPassed { get; set; }
        public string CheckError { get; set; }

        public ViewOpportunity()
        {

        }

        public ViewOpportunity(Opportunity pOpportunity)
        {
            Service.mapper.Map<Opportunity, ModelViews.ViewOpportunity>(pOpportunity, this);
        }

        public static List<ViewOpportunity> GetList(System.DateTime pDate, int pLastOpportunityID=0)
        {
            List<ViewOpportunity> colReturn = new List<ViewOpportunity>();

            List<Opportunity> colOpps = Opportunity.GetList(pDate, pLastOpportunityID);

            foreach(Opportunity op in colOpps)
            {
                ViewOpportunity vop = new ViewOpportunity(op);
                colReturn.Add(vop);
            }

            return colReturn;
        }
    }
}
