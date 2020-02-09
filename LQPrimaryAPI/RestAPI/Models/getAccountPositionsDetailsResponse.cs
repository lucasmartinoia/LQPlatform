using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getAccountPositionsDetailsResponse
    {
        public class DetailedDailyDiff
        {
            public double buyPricePPPDiff { get; set; }
            public int sellPricePPPDiff { get; set; }
            public double totalDailyDiff { get; set; }
            public double buyDailyDiff { get; set; }
            public double sellDailyDiff { get; set; }
            public double totalDailyDiffPlain { get; set; }
            public double buyDailyDiffPlain { get; set; }
            public double sellDailyDiffPlain { get; set; }
        }

        public class DetailedPosition2
        {
            public string symbolReference { get; set; }
            public object settlType { get; set; }
            public string contractType { get; set; }
            public double priceConversionFactor { get; set; }
            public double contractSize { get; set; }
            public double marketPrice { get; set; }
            public string currency { get; set; }
            public double exchangeRate { get; set; }
            public int totalInitialSize { get; set; }
            public int buyInitialSize { get; set; }
            public int sellInitialSize { get; set; }
            public int buyInitialPrice { get; set; }
            public int sellInitialPrice { get; set; }
            public double totalFilledSize { get; set; }
            public double buyFilledSize { get; set; }
            public int sellFilledSize { get; set; }
            public double buyFilledPrice { get; set; }
            public int sellFilledPrice { get; set; }
            public double totalCurrentSize { get; set; }
            public double buyCurrentSize { get; set; }
            public int sellCurrentSize { get; set; }
            public DetailedDailyDiff detailedDailyDiff { get; set; }
            public object marketValue { get; set; }
        }

        //TODO: VER COMO RESOLVER CUANDO HAGA PRUEBAS
        public class DLR122021
        {
            public List<DetailedPosition2> detailedPositions { get; set; }
            public object instrumentMarketValue { get; set; }
            public int instrumentInitialSize { get; set; }
            public double instrumentFilledSize { get; set; }
            public double instrumentCurrentSize { get; set; }
        }

        public class FUTURE
        {
            public DLR122021 DLR122021 { get; set; }
        }

        public class Report
        {
            public FUTURE FUTURE { get; set; }
        }

        public class DetailedPosition
        {
            public string account { get; set; }
            public double totalDailyDiffPlain { get; set; }
            public object totalMarketValue { get; set; }
            public Report report { get; set; }
            public long lastCalculation { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public DetailedPosition detailedPosition { get; set; }
        }
    }
}
