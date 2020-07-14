using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LQTrader.ModelViews
{
    public class ViewAcceptedOpportunity
    {
        public int AcceptedOpportunityID { get; set; }
        public DateTime AcceptedDateTime { get; set; }
        public int OpportunityID { get; set; }
        public string Status { get; set; }
        public string OrderID1 { get; set; }
        public string OrderID2 { get; set; }
        public string OrderID3 { get; set; }
        public bool AutoTrade { get; set; }
        public decimal CashReserved { get; set; }
        public DateTime LastUpdate { get; set; }
        public string ErrorDescription { get; set; }
        public bool Simulation { get; set; }
        public bool EntriesChecked { get; set; }

        public ViewAcceptedOpportunity()
        {

        }

        public ViewAcceptedOpportunity(LatamQuants.Entities.AcceptedOpportunity pAcceptedOpportunity)
        {
            Service.mapper.Map<LatamQuants.Entities.AcceptedOpportunity, ModelViews.ViewAcceptedOpportunity>(pAcceptedOpportunity, this);
        }

        public static List<ViewAcceptedOpportunity> GetList(int pStrategyID, System.DateTime pDate)
        {
            List<ViewAcceptedOpportunity> colReturn = new List<ViewAcceptedOpportunity>();

            List<LatamQuants.Entities.AcceptedOpportunity> colAcceptedOpps = LatamQuants.Entities.AcceptedOpportunity.GetList(0,pDate);

            foreach (LatamQuants.Entities.AcceptedOpportunity op in colAcceptedOpps)
            {
                ViewAcceptedOpportunity vop = new ViewAcceptedOpportunity(op);
                colReturn.Add(vop);
            }

            return colReturn;
        }
    }
}
