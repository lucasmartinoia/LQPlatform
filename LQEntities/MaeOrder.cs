using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    //#region Region Enums

    ///// <summary>
    ///// Enum Role of the PartyID.
    ///// </summary>
    //enum EnumPartyRole
    //{
    //    ExecutingFirm = 1,
    //    ContraFirm = 17,
    //    TradingMnemonicMandatory = 53,
    //    ClearingMnemonic = 83
    //}

    ///// <summary>
    ///// Enum Type of the investor account.
    ///// </summary>
    //enum EnumAccountType
    //{
    //    Client = 1,
    //    House = 3,
    //    Custodian = 100
    //}

    ///// <summary>
    ///// Enum indicates type of security.
    ///// </summary>
    //enum EnumSecurityType
    //{
    //    CS,
    //    GO,
    //    OPTO,
    //    CORP,
    //    CD,
    //    QS,
    //    TERM,
    //    STN,
    //    Plazo,
    //    T
    //}

    ///// <summary>
    ///// Enum Identifier of the order book.
    ///// </summary>
    //enum EnumOrderBook
    //{
    //    Regular = 1,
    //    OddLot = 3,
    //    BlockTrade = 4,
    //    AllOrNone = 5,
    //    EarlySettlement = 6,
    //    Auction = 7,
    //    BulletinBoard = 9
    //}

    ///// <summary>
    ///// Enum Time qualifier of the order
    ///// </summary>
    //enum EnumTimeInForce
    //{
    //    Day = 0,
    //    GoodTillCancel = 1,
    //    AtTheOpen = 2,
    //    ImmediateOrCancel = 3,
    //    FillOrKill = 4,
    //    GoodTillDate = 6,
    //    AtTheClose = 7,
    //    GoodForAuction = 9
    //}

    ///// <summary>
    ///// Enum side of the order
    ///// </summary>
    //enum EnumSide
    //{
    //    Buy = 1,
    //    Sell = 2,
    //    SellShort = 5
    //}

    ///// <summary>
    ///// Enum SettlType
    ///// </summary>
    //public enum EnumSettlType
    //{
    //    CashT = 1,
    //    NextDayTmore1 = 2,
    //    Tmore2 = 3
    //}

    ///// <summary>
    ///// Enum TradeFlag
    ///// </summary>
    //enum EnumTradeFlag
    //{
    //    NONE = 1,
    //    PASS = 2,
    //    BLOCK = 3
    //}

    ///// <summary>
    ///// Enum MultiLegReportingType
    ///// </summary>
    //enum EnumMultiLegReportingType
    //{
    //    TradeOfSingleIntrument = 1,
    //    LegTradeOfaMultiLegInstrumentTrade = 2,
    //    TradeOfaMultiLegInstrument = 3
    //}

    ///// <summary>
    ///// Enum ExecRestatementReason
    ///// </summary>
    //enum EnumExecRestatementReason
    //{
    //    GTCorporateAction = 0,
    //    GTRenewalRestatement = 1,
    //    OrderRePriced = 3,
    //    MarketOption = 8,
    //    OrderReplenishment = 1000
    //}

    //#endregion

    /// <summary>
    /// The NewOrderSingle message is used by an entity to send 
    /// orders in an electronic manner to the market trading system.
    /// </summary>
    public class MaeOrder
    {
        public MaeOrder()
        {
            MsgType = "D";
            OrderCapacity = "A";
            TradeFlag = "1";
            NoPartyIDs = 1;
            PartyID = "dmax219b";
            PartyIDSource = "D";
            PartyRole = 53;
            TransactTime = DateTime.Now.ToString("yyyyMMdd");
        }
        /// <summary>
        /// Mae order ID.
        /// </summary>
        [Key]
        public int MaeOrderID { get; set; }

        public string MarketOwnOrderID { get; set; }

        /// <summary>
        /// Market order ID.
        /// Inherited from MarketOrder (1 to 1 relationship).
        /// </summary>
        public int MarketOrderID { get; set; }

        /// <summary>
        /// Market order.
        /// </summary>
        [Required]
        public virtual MarketOrder MarketOrder { get; set; }

        /// <summary>
        /// NewOrderSingle (MsgType = D)
        /// </summary>
        [StringLength(1)]
        public string MsgType { get; set; }

        /// <summary>
        /// Client specified identifier of the order.
        /// </summary>
        [StringLength(19)]
        public string ClOrdID { get; set; }

        /// <summary>
        /// Number of party identifiers.
        /// </summary>
        public int NoPartyIDs { get; set; }

        /// <summary>
        /// Identifier of the party.
        /// When tag 452 (Party Role) is 53 (Trading Mnemonic), this tag (448) identifies the operator who entersthe order.
        /// </summary>
        public string PartyID { get; set; }

        /// <summary>
        /// Source of the PartyID (448).
        /// Value:D Meaning: Proprietary/Custom Code
        /// </summary>
        [StringLength(1)]
        public string PartyIDSource { get; set; }

        /// <summary>
        /// Role of the PartyID (448). Specifying Trading Mnemonic (53) is mandatory.
        /// 1 Executing Firm
        /// 17 (**) Contra Firm
        /// 53 Trading Mnemonic(Mandatory)
        /// 83 (**) Clearing Mnemonic
        /// </summary>
        public int PartyRole { get; set; }

        /// <summary>
        /// Identifier of the investor account on whose behalf the order is submitted.
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
        /// Identifier of the instrument.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Indicates type of security.
        /// CS Common Stock
        /// GO General Obligation Bonds
        /// OPTO ption
        /// CORP Corporate Bonds
        /// CD Certificate of Deposit
        /// QS Caution
        /// TERM TermLoan
        /// STN Short Term Loan
        /// Plazo Plazo
        /// T Plazo por Lotes
        /// </summary>
        public string SecurityType { get; set; }

        /// <summary>
        /// Indentifies currency used for price
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Identifier of the order book. Absence of this field is interpreted as Regular (1)
        /// 1 Regular
        /// 3 Odd Lot
        /// 4 Block Trade
        /// 5 All or None
        /// 6 Early Settlement
        /// 7 Auction
        /// 9 Bulletin Board
        /// </summary>
        public int? OrderBook { get; set; }

        /// <summary>
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
        /// Time the order expires which must be a time during the current trading day. 
        /// Required if TimeInForce (59) is GTD (6) and ExpireDate (432) is not specified
        /// </summary>
        public string ExpireTime { get; set; }

        /// <summary>
        /// Date the order expires. Required if TimeInForce (59) is GTD (6) and ExpireTime (126) is not specified.
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// Number of sessions the order is valid for. If specified, the value in this field should always be “1”.
        /// </summary>
        [StringLength(1)]
        public string NoTradingSessions { get; set; }

        /// <summary>
        /// Session the order is valid for.
        /// a Closing Price Cross
        /// </summary>
        [StringLength(1)]
        public string TradingSessionID { get; set; }

        /// <summary>
        /// Space separated field indicating specific instructions to be carried out on the order due to the events,
        /// user disconnect/logout and corporate actions.
        /// 
        /// n Do Not Cancel on Disconnect/Logout
        /// E Do Not Increase
        /// F Do Not Reduce
        /// 
        /// Campo separado por espacios que indica instrucciones específicas a realizar en el pedido 
        /// debido a los eventos, desconexión / cierre de sesión del usuario y acciones corporativas. (**)
        /// </summary>
        [StringLength(1)]
        public string ExecInst { get; set; }

        /// <summary>
        /// Side of the order.
        /// 1 Buy
        /// 2 Sell
        /// 5 Sell Short
        /// </summary>
        public string Side { get; set; }

        /// <summary>
        /// Total order quantity
        /// </summary>
        public int OrderQty { get; set; }

        /// <summary>
        /// Maximum quantity that may be displayed.
        /// </summary>
        public int? DisplayQty { get; set; }

        /// <summary>
        /// Whether the order is a reserve order.
        /// 4 Undisclosed (Reserve Order)
        /// </summary>
        public int? DisplayMethod { get; set; }

        /// <summary>
        /// Minimum quantity that must be filled.
        /// </summary>
        public decimal MinQty { get; set; }

        /// <summary>
        /// Limit price. Required if OrderType (40) is Limit (2) or Stop Limit (4).
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// Stop price. Required if OrderType (40) is Stop (3) or Stop Limit (4) and no value specified for PegOffsetValue (211)
        /// </summary>
        public double? StopPx { get; set; }

        /// <summary>
        /// Trailing Offset added to trailing stop/stop limit orders. Only positive values are allowed with the value zero
        /// </summary>
        public int? PegOffsetValue { get; set; }

        /// <summary>
        /// Whether the order is anonymous or named. Absence of this field is interpreted as Anonymous (Y)
        /// Y Anonymous
        /// N Named
        /// </summary>
        [StringLength(1)]
        public string PreTradeAnonymity { get; set; }

        /// <summary>
        /// Capacity of the order. Absence of this field is interpreted as Agency (A).
        /// A Agency
        /// P Principal
        /// </summary>
        [StringLength(1)]
        public string OrderCapacity { get; set; }

        /// <summary>
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
        /// Free form text of up to tencharacters. 
        /// The specified string will be included in all Execution Reports generated for the order.
        /// </summary>
        public string OrderSource { get; set; }

        /// <summary>
        /// Time the order was created.
        /// </summary>
        public string TransactTime { get; set; }

        /// <summary>
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
        /// 1 NONE
        /// 2 PASS
        /// 3 BLOCK
        /// </summary>
        public string TradeFlag { get; set; }

        public string SecurityExchange { get; set; }

        public string CFICode { get; set; }

        /// <summary>
        /// Mae´s Trades generated to satisfy this Mae Order.
        /// </summary>
        public virtual List<MaeExecutionReport> MaeExecutionsReport { get; set; }

        /// <summary>
        /// Order Communication Status: S = Sent, E = Error, C = Completed.
        /// </summary>
        [StringLength(1)]
        public string CommStatus { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        public static void Save(MaeOrder MaeOrder)
        {
            using (var db = new DBContext())
            {
                db.MaeOrders.Add(MaeOrder);
                db.SaveChanges();
            }
        }

        public static void Update(MaeOrder MaeOrder)
        {
            using (var db = new DBContext())
            {
                db.MaeOrders.Update(MaeOrder);
                db.Entry(MaeOrder).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
