using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI;

namespace LQTrader.ModelViews
{
    class InstrumentDetail
    {
        public string Symbol { get; set; }
        public string MarketID { get; set; }
        public string SegmentID { get; set; }
        public double LowLimitPrice { get; set; }
        public double HighLimitPrice { get; set; }
        public double MinPriceIncrement { get; set; }
        public double MinTradeVol { get; set; }
        public double MaxTradeVol { get; set; }
        public double TickSize { get; set; }
        public double ContractMultiplier { get; set; }
        public double RoundLot { get; set; }
        public double PriceConvertionFactor { get; set; }
        public DateTime MaturityDate { get; set; }
        public string Currency { get; set; }
        public string OrderTypes { get; set; }
        public string TimesInForce { get; set; }
        public string SecurityType { get; set; }
        public string SettlementType { get; set; }
        public int InstrumentPricePrecision { get; set; }
        public int InstrumentSizePrecision { get; set; }
        public string CFICode { get; set; }

        public static List<InstrumentDetail> GetInstrumentsDetails()
        {
            List<ModelViews.InstrumentDetail> colReturn = new List<ModelViews.InstrumentDetail>();

            List<LatamQuants.PrimaryAPI.Models.InstrumentDetails> colInstrumentsDetails = RestAPI.GetInstrumentsDetails().instruments;

            foreach (LatamQuants.PrimaryAPI.Models.InstrumentDetails oinstrumentDetails in colInstrumentsDetails)
            {
                ModelViews.InstrumentDetail vInstrumentDetails = new InstrumentDetail();
                Service.mapper.Map<LatamQuants.PrimaryAPI.Models.InstrumentDetails, ModelViews.InstrumentDetail>(oinstrumentDetails, vInstrumentDetails);
                colReturn.Add(vInstrumentDetails);
            }

            return colReturn;
        }
    }
}
