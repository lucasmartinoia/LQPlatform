using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI;

namespace LQTrader.ModelViews
{
    public class MarketDataHistoric
    {
        public string Symbol {get; set; }
        public string DateTime { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }

        public static List<MarketDataHistoric> GetMarketDataHistoric(string pMarketID, string pSymbol, DateTime pDateFrom, DateTime pDateTo, bool pExternal, string pEnvironment)
        {
            List<MarketDataHistoric> colReturn = new List<MarketDataHistoric>();

            List<LatamQuants.PrimaryAPI.Models.Trade> colMDTrades=RestAPI.GetMarketDataInstrumentHistoric(pMarketID,pSymbol,pDateFrom,pDateTo,pExternal,pEnvironment).trades;

            // Market Data Historic
            if(colMDTrades!=null)
            {
                foreach(LatamQuants.PrimaryAPI.Models.Trade oTrade in colMDTrades)
                {
                    MarketDataHistoric ovMDHistoric = new MarketDataHistoric();
                    Service.mapper.Map<LatamQuants.PrimaryAPI.Models.Trade, MarketDataHistoric>(oTrade, ovMDHistoric);
                    colReturn.Add(ovMDHistoric);
                }
            }

            return colReturn;
        }
    }
}
