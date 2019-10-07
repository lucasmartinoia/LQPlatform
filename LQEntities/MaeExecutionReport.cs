using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    #region - Comentario
    /*Wrap for ExecutionReport (Response of message, NewOrderSingle)
     * The execution report message is used to:
      1. confirm the receipt of an order
      2. confirm changes to an existing order (i.e. accept cancel and replace requests)
      3. relay order status information
      4. relay fill information on working orders
      5. relay fill information on tradeable or restricted tradeable quotes
      6. reject orders
      7. report post-trade fees calculations associated with a trade
   */
    #endregion

    [JsonObject(IsReference = true)]
    public class MaeExecutionReport
    {
        public MaeExecutionReport()
        {
            MsgType = "8";
            OrderCapacity = "A";
            NoPartyIDs = 1;
            PartyIDSource = "D";
            PartyRole = 53;
            TransactTime = DateTime.Now;
            ApplID = "1";
        }
        /// <summary>
        /// Server specified identifier of the message.
        /// </summary>
        [Key]
        public string ExecID { get; set; }

        /// <summary>
        /// Market order ID.
        /// </summary>
        public int MarketOrderID { get; set; }

        /// <summary>
        /// MaeOrderID
        /// </summary>
        public int MaeOrderID { get; set; }

        /// <summary>
        /// Object MaeOrder order.
        /// </summary>
        [Required]
        public MaeOrder MaeOrder { get; set; }

        /// <summary>
        /// 8 = Execution Report
        /// </summary>
        [StringLength(1)]
        public string MsgType { get; set; }

        /// <summary>
        /// Identity of the partition.
        /// </summary>
        public string ApplID { get; set; }



        /// <summary>
        /// Client specified identifier of the order.
        /// </summary>
        [StringLength(19)]
        public string ClOrdID { get; set; }

        /// <summary>
        /// Server specified public order identified or the order
        /// </summary>
        public string MDEntryID { get; set; }

        /// <summary>
        /// ClOrdID (11), of the order which has been amended or cancelled. 
        /// Stamped only in the immediate ER generated to convey an amendment/cancellation
        /// </summary>
        public string OrigClOrdID { get; set; }

        /// <summary>
        /// Server specified identifier of the order
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// Type of Trade. Absence of this field is interpreted as Trade of Single Instrument (1).
        /// 1 Trade of Single Instrument
        /// 2 Leg Trade of a Multi-Leg Instrument Trade
        /// 3 Trade of a Multi-Leg Instrument
        /// </summary>
        public int? MultiLegReportingType { get; set; }

        /// <summary>
        /// Server specified identifier of the order for the multi-legged instrument. 
        /// Required if MultiLegReportingType (442) is Leg Trade of a Multi-Leg Instrument Trade (2)
        /// </summary>
        public string SecondaryOrderID { get; set; }

        /// <summary>
        /// Reason the execution report was generated
        /// 0 New
        /// 4 Cancelled
        /// 5 Replaced
        /// 8 Rejected
        /// 9 Suspended
        /// A Pending New
        /// C Expired
        /// D Restated
        /// E Pending Replace
        /// F Trade
        /// G Trade Correct
        /// H Trade Cancel
        /// L Triggered
        /// </summary>
        [StringLength(1)]
        public string ExecType { get; set; }



        /// <summary>
        /// Identifier of the trade. Required if ExecType (150) is Trade (F), 
        /// Trade Correct (G) or Trade Cancel (H).
        /// </summary>
        public string TrdMatchID { get; set; }

        /// <summary>
        /// Reference to the execution being cancelled or corrected. 
        /// Required if ExecType (150) is Trade Cancel (H) or Trade Correct (G)
        /// </summary>
        public string ExecRefID { get; set; }

        /// <summary>
        /// Reason the order was restated or cancelled by Market Operations. 
        /// Required if ExecType (150) is Restated (D) or if the execution report is sent for an unsolicited cancellation.
        /// 0 GT Corporate Action
        /// 1 GT Renewal/Restatement
        /// 3 Order Re-Priced
        /// 8 Market Option
        /// 100 Order Replenishment
        /// </summary>
        public int? ExecRestatementReason { get; set; }

        /// <summary>
        /// Current status of the order.
        /// 0 New
        /// 1 Partially Filled
        /// 2 Filled
        /// 4 Cancelled
        /// 8 Rejected
        /// 9 Suspended
        /// A Pending New
        /// C Expired
        /// E Pending Replace
        /// </summary>
        [StringLength(1)]
        public string OrdStatus { get; set; }

        /// <summary>
        /// Whether the order is currently being worked
        /// N Order is Not in a Working State
        /// Y Order is Being Worked
        /// </summary>
        [StringLength(1)]
        public string WorkingIndicator { get; set; }

        /// <summary>
        /// Code specifying the reason for the reject. 
        /// Required if ExecType (150) is Rejected (8)
        /// </summary>
        public int? OrdRejReason { get; set; }

        /// <summary>
        /// Text specifying the reason for the rejection, cancellation or expiration.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Quantity executed in this fill. 
        /// Required if ExecType (150) is Trade (F) or Trade Correct (G).
        /// </summary>
        public decimal? LastQty { get; set; }

        /// <summary>
        /// Price of this fill. 
        /// Required if ExecType (150) is Trade (F) or Trade Correct (G).
        /// </summary>
        public decimal? LastPx { get; set; }

        /// <summary>
        /// Price per unit of the trade. 
        /// Required if LastPx (31) is specified and the trade is for a fixed 
        /// income instrument quoted on discount rate or yield.
        /// </summary>
        public double? LastParPx { get; set; }

        /// <summary>
        /// Implied yield of this fill. 
        /// Required if LastPx (31) is specified and the trade is for a fixed income instrument quoted 
        /// on price per unit or on percentage of par.
        /// 
        /// Rendimiento implícito de este relleno. 
        /// Se requiere si se especifica LastPx (31) y la transacción es para un instrumento de renta fija 
        /// cotizado en el precio por unidad o en el porcentaje del valor nominal.
        /// </summary>
        public string Yield { get; set; }

        /// <summary>
        /// Accrued Interest for a unit trade if executed on the current trading day. 
        /// Multiplying this by the LastPx(31) if available, gives the Total accrued interest. 
        /// May only apply for a Regular Coupon Bond or TIPS
        /// </summary>
        public string AccruedInterestAmt { get; set; }


        /// <summary>
        /// Quantity available for further execution. 
        /// Will be “0” if OrdStatus (39) is Filled (2), Cancelled (4), Rejected (8) or Expired (C).
        /// </summary>
        public decimal? LeavesQty { get; set; }

        /// <summary>
        /// Total cumulative quantity filled.
        /// </summary>
        public decimal? CumQty { get; set; }

        /// <summary>
        /// Average price of all fills for the order.
        /// </summary>
        public double? AvgPx { get; set; }

        /// <summary>
        /// Indentifier of the instrument.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Indicates type of security
        /// CS Common Stock
        /// GO General Obligation Bonds
        /// OPT Option
        /// CORP Corporate Bonds
        /// CD Certificate of Deposit
        /// QS Caution
        /// TERM Term Loan
        /// STN Short Term Loan
        /// Plazo Plazo 
        /// T Plazo por Lotes
        /// </summary>
        public string SecurityType { get; set; }

        /// <summary>
        /// Indicates currency for price
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Converted clean price of an order’s limit price. 
        /// If computed, it will be on the Price (44) of an order belonging to a fixed income instrument quoted on discount rate or yield
        /// </summary>
        public string ParPx { get; set; }

        /// <summary>
        /// Converted yield value of an order’s limit price. 
        /// If computed, it will be on the Price (44) of an order belonging to a fixed income instrument quoted 
        /// on price per unit or on percentage-of-par.
        /// </summary>
        public string ConvertedYield { get; set; }

        /// <summary>
        /// Identifier of the order book.
        /// 1 Regular
        /// 3 Odd Lot
        /// 4 Block Trade
        /// 5 Allor None
        /// 6 Early Settlement
        /// 7 Auction
        /// 9 Bulletin Board
        /// </summary>
        public int? OrderBook { get; set; }

        /// <summary>
        /// Number of party identifiers.
        /// </summary>
        public int? NoPartyIDs { get; set; }

        /// <summary>
        /// Identifier of the party.
        /// </summary>
        public int? PartyID { get; set; }

        /// <summary>
        /// Required if PartyID (448) is specified
        /// Value:D Meaning: Proprietary/Custom Code
        /// </summary>
        [StringLength(1)]
        public string PartyIDSource { get; set; }

        /// <summary>
        /// Role of the PartyID (448). Required if PartyID (448) is specified.
        /// 1 Executing Firm
        /// 17 Contra Firm
        /// 53 Trading Mnemonic
        /// 83 Clearing Mnemonic
        /// </summary>
        public int? PartyRole { get; set; }

        /// <summary>
        /// Identifier of the investor account.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Type of the investor account.
        /// 1 Client 
        /// 3 House
        /// 100 Custodian
        /// </summary>
        public int? AccountType { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Type of order
        /// 1 Market
        /// 2 Limit
        /// 3 Stop
        /// 4 Stop Limit
        /// K Market to Limit
        /// J Market If Touched
        /// </summary>
        [StringLength(1)]
        public string OrdType { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Time qualifier of the order. Absence of this field is interpreted as Day (0).
        /// 0 Day
        /// 1 GoodTill Cancel (GTC)
        /// 2 At the Open (OPG)
        /// 3 Immediate or Cancel (IOC)
        /// 4 Fill or Kill (FOK)
        /// 6 Good Till Date (GTD)
        /// 7 At the Close (ATC) 
        /// 9 Good for Auction (GFA)
        /// </summary>
        public string TimeInForce { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Time the order expires which must be a time during the current trading day. 
        /// Required if TimeInForce (59) is GTD (6) and ExpireDate (432) is not specified
        /// </summary>
        public string ExpireTime { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Date the order expires. Required if TimeInForce (59) is GTD (6) and ExpireTime (126) is not specified.
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Session the order is valid for.
        /// </summary>
        [StringLength(1)]
        public string TradingSessionID { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Space separated field indicating specific instructions to be carried out on the order due to the events,
        /// user disconnect/logout and corporate actions.
        /// n Do Not Cancel on Disconnect/Logout
        /// E Do Not Increase
        /// F Do Not Reduce
        /// </summary>
        [StringLength(1)]
        public string ExecInst { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Side of the order.
        /// 1 Buy
        /// 2 Sell
        /// 5 Sell Short
        /// </summary>
        public string Side { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Total order quantity
        /// </summary>
        public decimal? OrderQty { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Maximum quantity that may be displayed.
        /// </summary>
        public decimal? DisplayQty { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Whether the order is a reserve order.
        /// 4 Undisclosed (Reserve Order)
        /// </summary>
        public int? DisplayMethod { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Minimum quantity that must be filled.
        /// </summary>
        public int? MinQty { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Limit price. Required if OrderType (40) is Limit (2) or Stop Limit (4).
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Stop price. Required if OrderType (40) is Stop (3) or Stop Limit (4) and no value specified for PegOffsetValue (211)
        /// </summary>
        public decimal? StopPx { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Trailing Offset added to trailing stop/stop limit orders. Only positive values are allowed with the value zero
        /// </summary>
        public int? PegOffsetValue { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Whether the order is anonymous or named. Absence of this field is interpreted as Anonymous (Y)
        /// Y Anonymous
        /// N Named
        /// </summary>
        [StringLength(1)]
        public string PreTradeAnonymity { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Capacity of the order. Absence of this field is interpreted as Agency (A).
        /// A Agency
        /// P Principal
        /// </summary>
        [StringLength(1)]
        public string OrderCapacity { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Deal identifier agreed with counterparty. 
        /// Required if OrderBook (30001) is Block Trade (4) and order book configuration
        /// is to support negotiated non-disclosure orders
        /// 
        /// Identificador de acuerdo acordado con la contraparte. 
        /// Se requiere si OrderBook (30001) es Block Trade (4) y la configuración del libro 
        /// de pedidos es para admitir pedidos negociados de no divulgación
        /// </summary>
        public string ClOrdLinkID { get; set; }

        /// <summary>
        /// Value submitted with the order, cancel request or amend request
        /// Free form text of up to tencharacters. 
        /// The specified string will be included in all Execution Reports generated for the order.
        /// </summary>
        [StringLength(10)]
        public string OrderSource { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// Time the order was created.
        /// </summary>
        public DateTime TransactTime { get; set; }

        /// <summary>
        /// Value submitted with the order.
        /// For NDFs either SettlType or SettlDate should be specified
        /// 1 Cash(T)
        /// 2 Next Day (T+1)
        /// 3 T+2
        /// </summary>
        public string SettlType { get; set; }

        /// <summary>
        /// For NDFs either SettlType or SettlDate shoul be specified(yyyymmdd)
        /// </summary>
        public string SettlDate { get; set; }

        /// <summary>
        /// 1 Yes 
        /// 0 No
        /// </summary>
        public bool PriceSetter { get; set; }

        /// <summary>
        /// Numeric Order ID assigned for the order.
        /// </summary>
        public int NumericOrderID { get; set; }

        /// <summary>
        /// Server specified identifier of a private RFQ
        /// </summary>
        public string RFQID { get; set; }

        /// <summary>
        /// Numeric trade ID assigned for the trade
        /// </summary>
        public int SecondaryTradeID { get; set; }

        /// <summary>
        /// Numeric Instrument ID
        /// </summary>
        public string SecurityID { get; set; }

        /// <summary>
        /// M (Always)
        /// </summary>
        [StringLength(1)]
        public string SecurityIDSource { get; set; }

        /// <summary>
        /// 1 NONE
        /// 2 PASS
        /// 3 BLOCK
        /// </summary>
        [StringLength(1)]
        public string TradeFlag { get; set; }

        public string SecondaryClOrdID { get; set; }
        public int? TotNumReports { get; set; }
        public bool? LastRptRequested { get; set; }

        public static void Save(MaeExecutionReport MaeExecutionReport)
        {
            using (var db = new DBContext())
            {
                db.MaeExecutionReports.Add(MaeExecutionReport);
                db.SaveChanges();
            }
        }
    }

}
