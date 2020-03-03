using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI;

namespace LQTrader.ModelViews
{
    public class PositionDetail
    {
        public string SymbolReference { get; set; }
        public string Symbol { get; set; }
        public double BuyPrice { get; set; }
        public double BuySize { get; set; }
        public double SellPrice { get; set; }
        public double SellSize { get; set; }
        public double TotalDailyDiff { get; set; }
        public double TotalDiff { get; set; }
        public double OriginalBuyPrice { get; set; }
        public double OriginalSellPrice { get; set; }

        public static object GetPositionDetails()
        {
            ModelViews.PositionDetail oReturn = new ModelViews.PositionDetail();

            LatamQuants.PrimaryAPI.Models.getAccountPositionsDetailsResponse.RootObject oPositionDetails=RestAPI.GetAccountPositionsDetails();

            //foreach(LatamQuants.PrimaryAPI.Models.getAccountPositionsResponse.Position oPosition in colPositions)
            //{
            //    ModelViews.Position vPosition = new Position();
            //    Service.mapper.Map<LatamQuants.PrimaryAPI.Models.getAccountPositionsResponse.Position, ModelViews.Position>(oPosition, vPosition);
            //    colReturn.Add(vPosition);
            //}

            return oReturn;
        }
    }
}
