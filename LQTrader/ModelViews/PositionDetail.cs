using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI;

namespace LQTrader.ModelViews
{
    public class PositionDetailMain
    {
        public DetailedPosition Details { get; set; }
        public List<Position> Positions { get; set; }
        public List<PositionDetail> PositionDetails { get; set; }
        public List<PositionDetailDailyDifference> PositionDetailDailyDifferences { get; set; }

        public class Position
        {
            public string SymbolReference { get; set; }
            public double InitialSize { get; set; }
            public double FilledSize { get; set; }
            public double CurrentSize { get; set; }
            public string ContractType { get; set; }
            public double PriceConversionFactor { get; set; }
            public double ContractSize { get; set; }
            public double MarketPrice { get; set; }
            public string Currency { get; set; }
            public double ExchangeRate { get; set; }
            public double ContractMultiplier { get; set; }
        }

        public class DetailedPosition
        {
            public string Account { get; set; }
            public double TotalDailyDiffPlain { get; set; }
            public double TotalMarketValue { get; set; }
            public string LastCalculation { get; set; }
        }

        public class PositionDetail
        {
            public int Id { get; set; }
            public string SymbolReference { get; set; }
            public double TotalInitialSize { get; set; }
            public double BuyInitialSize { get; set; }
            public double SellInitialSize { get; set; }
            public double BuyInitialPrice { get; set; }
            public double SellInitialPrice { get; set; }
            public double TotalFilledSize { get; set; }
            public double BuyFilledSize { get; set; }
            public double SellFilledSize { get; set; }
            public double BuyFilledPrice { get; set; }
            public double SellFilledPrice { get; set; }
            public double TotalCurrentSize { get; set; }
            public double BuyCurrentSize { get; set; }
            public double SellCurrentSize { get; set; }
        }

        public class PositionDetailDailyDifference
        {
            public int Id { get; set; }
            public string Item { get; set; }
            public double Buy { get; set; }
            public double Sell { get; set; }
            public double Total { get; set; }
        }

        public static PositionDetailMain GetPositionDetails()
        {
            ModelViews.PositionDetailMain oReturn = new ModelViews.PositionDetailMain();

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
