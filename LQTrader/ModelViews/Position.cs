using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI;

namespace LQTrader.ModelViews
{
    public class Position
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

        public static List<Position> GetPositions()
        {
            List<ModelViews.Position> colReturn = new List<ModelViews.Position>();

            List<LatamQuants.PrimaryAPI.Models.getAccountPositionsResponse.Position> colPositions=RestAPI.GetAccountPositions().positions;

            foreach(LatamQuants.PrimaryAPI.Models.getAccountPositionsResponse.Position oPosition in colPositions)
            {
                ModelViews.Position vPosition = new Position();
                Service.mapper.Map<LatamQuants.PrimaryAPI.Models.getAccountPositionsResponse.Position, ModelViews.Position>(oPosition, vPosition);
                colReturn.Add(vPosition);
            }

            return colReturn;
        }
    }
}
