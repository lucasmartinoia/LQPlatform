using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI;

namespace LQTrader.ModelViews
{
    public class MarketDataRT
    {
        public List<MarketDataItem> MainInfo {get; set; }
        public List<MarketDataDepthItem> Bids { get; set; }
        public List<MarketDataDepthItem> Offers { get; set; }

        public static MarketDataRT GetMarketDataRT(string pMarketID, string pSymbol, int pDepth)
        {
            MarketDataRT oReturn = new MarketDataRT();

            LatamQuants.PrimaryAPI.Models.getMarketDataInstrumentRealTimeResponse.MarketData oMarketDataRT=RestAPI.GetMarketDataInstrumentRealTime(pMarketID,pSymbol, "BI,OF,LA,OP,CL,SE,OI", pDepth).marketData;

            // Populate main info
            oReturn.MainInfo = new List<MarketDataItem>();
            MarketDataItem oMDItem = new MarketDataItem();

            // OP -  Open Price
            if (oMarketDataRT.OP != null)
            {
                oMDItem.Name = "Open price";
                oMDItem.Price = (double)oMarketDataRT.OP;
                oReturn.MainInfo.Add(oMDItem);
            }

            // LA - Last Price
            if (oMarketDataRT.LA != null)
            {
                oMDItem = new MarketDataItem();
                Service.mapper.Map<LatamQuants.PrimaryAPI.Models.MarketDataRT, ModelViews.MarketDataRT.MarketDataItem>(oMarketDataRT.LA, oMDItem);
                oMDItem.Name = "Last price";
                oReturn.MainInfo.Add(oMDItem);
            }

            // SE - Settlement
            if (oMarketDataRT.SE != null)
            {
                oMDItem = new MarketDataItem();
                Service.mapper.Map<LatamQuants.PrimaryAPI.Models.MarketDataRT, ModelViews.MarketDataRT.MarketDataItem>(oMarketDataRT.SE, oMDItem);
                oMDItem.Name = "Settlement";
                oReturn.MainInfo.Add(oMDItem);
            }

            // OI - Open Interest
            if (oMarketDataRT.OI != null)
            {
                oMDItem = new MarketDataItem();
                Service.mapper.Map<LatamQuants.PrimaryAPI.Models.MarketDataRT, ModelViews.MarketDataRT.MarketDataItem>(oMarketDataRT.OI, oMDItem);
                oMDItem.Name = "Open interest";
                oReturn.MainInfo.Add(oMDItem);
            }

            // CL - Close Price
            if (oMarketDataRT.CL != null)
            {
                oMDItem = new MarketDataItem();
                oMDItem.Name = "Close price";
                oMDItem.Price = (double)oMarketDataRT.CL;
                oReturn.MainInfo.Add(oMDItem);
            }

            // Populate Bids
            if (oMarketDataRT.BI != null)
                oReturn.Bids = PopulateDepth(oMarketDataRT.BI);
            else
                oReturn.Bids = new List<MarketDataDepthItem>();

            // Populate Offers
            if (oMarketDataRT.OF != null)
                oReturn.Offers = PopulateDepth(oMarketDataRT.OF);
            else
                oReturn.Offers = new List<MarketDataDepthItem>();

            return oReturn;
        }

        private static List<MarketDataDepthItem> PopulateDepth(List<LatamQuants.PrimaryAPI.Models.MarketDataRT> colDepthItems)
        {
            List<ModelViews.MarketDataRT.MarketDataDepthItem> colReturn = new List<MarketDataDepthItem>();

            foreach(LatamQuants.PrimaryAPI.Models.MarketDataRT oDepthItem in colDepthItems)
            {
                MarketDataDepthItem ovDepthItem = new MarketDataDepthItem();
                ovDepthItem.Price = (double)oDepthItem.price;
                ovDepthItem.Size = (double)oDepthItem.size;
                colReturn.Add(ovDepthItem);
            }

            return colReturn;
        }

        public class MarketDataItem
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public double Size { get; set; }
            public string Date { get; set; }
        }

        public class MarketDataDepthItem
        {
            public double Price { get; set; }
            public double Size { get; set; }
        }
    }
}
