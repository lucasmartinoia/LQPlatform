using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace INOM.Entities
{
    public partial class BymaTradeCaptureReport
    {
        public BymaTradeCaptureReport()
        {
            MsgType = "AE";
        }
        [Key]
        public string TradeReportID { get; set; }

        public int BymaOrderID { get; set; }
        public int MarketOrderID { get; set; }
        [StringLength(1)]
        public string MsgType { get; set; }
        public string Currency { get; set; }
        [StringLength(1)]
        public string IDSource { get; set; }
        public decimal? LastPx { get; set; }
        public decimal? LastQty { get; set; }
        
        public int? LastShares { get; set; }
        public string SecurityID { get; set; }
        public string Symbol { get; set; }
        public DateTime? TransactTime { get; set; }
        [StringLength(1)]
        public string SettlmntTyp { get; set; }
        public string FutSettDate { get; set; }
        [StringLength(1)]
        public string ExecType { get; set; }
        [StringLength(1)]
        public string SecurityType { get; set; }
        public decimal GrossTradeAmt { get; set; }
        public int PriceType { get; set; }
        [StringLength(1)]
        public string MultiLegReportingType { get; set; }
        public int TradeReportTransType { get; set; }
        [StringLength(1)]
        public string MatchStatus { get; set; }
        [StringLength(1)]
        public string MatchType { get; set; }
        public string TradeLinkID { get; set; }
        public int TrdType { get; set; }
        public int TradeReportType { get; set; }
        public string TradeID { get; set; }
        [StringLength(1)]
        public string SecondaryTradeID { get; set; }
        public string LotType { get; set; }
        public string TradeHandlingInstr { get; set; }
        public string ApplID { get; set; }
        public int? ApplSeqNum { get; set; }
        public string ProductComplex { get; set; }
        public int? ApplLastSeqNum { get; set; }
        public bool? ApplResendFlag { get; set; }
        public string NumericOrderID { get; set; }
        public string PriceSetter { get; set; }
        public int NoSides { get; set; }
        [StringLength(1)]
        public string Side { get; set; }
        public string OrderID { get; set; }
        public string ClOrdID { get; set; }
        public string Account { get; set; }
        public int AccountType { get; set; }
        [StringLength(1)]
        public string OrderCapacity { get; set; }
        public decimal NetMoney { get; set; }
        [StringLength(1)]
        public string OrderCategory { get; set; }
        public string SideExecID { get; set; }
        public string SideLiquidityInd { get; set; }

        public string MaturityDate { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        


        public static void Save(BymaTradeCaptureReport bymaTradeCaptureReport)
        {
            using (var db = new DBContext())
            {
                db.BymaTradeCaptureReports.Add(bymaTradeCaptureReport);
                db.SaveChanges();
            }
        }
    }
}
