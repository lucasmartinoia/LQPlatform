using Newtonsoft.Json;
using LatamQuants.PrimaryAPI.WebSocket.Serialization;

namespace LatamQuants.PrimaryAPI.Models.Websocket
{
    [JsonConverter(typeof(TypeJsonSerializer))]
    public enum Type
    {
        Market, 
        Limit
    }

    [JsonConverter(typeof(SideJsonSerializer))]
    public enum Side
    {
        Buy,
        Sell
    }

    [JsonConverter(typeof(ExpirationJsonSerializer))]
    public enum Expiration
    {
        /// <summary>Order valid during the day. It will expires when the market closes.</summary>
        Day,

        /// <summary>Immediate or cancel.</summary>
        ImmediateOrCancel,

        /// <summary>Fill or kill.</summary>
        FillOrKill,

        /// <summary>Good Till Date (Must send ExpirationDate field in the Order).</summary>
        GoodTillDate
    }

    [JsonConverter(typeof(StatusJsonSerializer))]
    public enum Status
    {
        /// <summary>The order was successfully submitted.</summary>
        New,
        
        /// <summary>The order was submitted, but it is still being processed.</summary>
        PendingNew,
        
        /// <summary>The order was rejected.</summary>
        Rejected,
        
        /// <summary>The order was cancelled.</summary>
        Cancelled,
        
        /// <summary>The order was cancelled, but it is still being processed.</summary>
        PendingCancel,

        /// <summary>The order was partially filled.</summary>
        PartiallyFilled,

        /// <summary>The order was filled.</summary>
        Filled
    }

    #region String serialization

    internal static class EnumsToApiStrings
    {
        #region Type

        public static string ToApiString(this Type value)
        {
            string sReturn = "";

            switch(value)
            {
                case Type.Market:
                    sReturn = "Market";
                    break;
                case Type.Limit:
                    sReturn = "Limit";
                    break;
                default:
                    sReturn = "";
                    break;
            }

            return sReturn;
        }

        public static Type TypeFromApiString(string value)
        {
            Type oReturn = Type.Limit;

            switch (value.ToUpper())
            {
                case "MARKET":
                    oReturn = Type.Market;
                    break;
                case "LIMIT":
                    oReturn = Type.Limit;
                    break;
            }

            return oReturn;
        }

        #endregion

        #region Side

        public static string ToApiString(this Side value)
        {
            return (value == Side.Buy ? "Buy" : "Sell");
        }

        public static Side SideFromApiString(string value)
        {
            return (value.ToUpper() == "Buy"? Side.Buy: Side.Sell);
        }

        #endregion

        #region Expiration

        public static string ToApiString(this Expiration value)
        {
            string sReturn = "";

            switch(value)
            {
                case Expiration.Day:
                    sReturn = "DAY";
                    break;
                case Expiration.FillOrKill:
                    sReturn = "FOK";
                    break;
                case Expiration.GoodTillDate:
                    sReturn = "GTD";
                    break;
                case Expiration.ImmediateOrCancel:
                    sReturn = "IOC";
                    break;
            }

            return sReturn;
        }

        public static Expiration ExpirationFromApiString(string value)
        {
            Expiration oReturn = Expiration.Day;

            switch (value)
            {
                case "DAY":
                    oReturn = Expiration.Day;
                    break;
                case "FOK":
                    oReturn = Expiration.FillOrKill;
                    break;
                case "GTD":
                    oReturn = Expiration.GoodTillDate;
                    break;
                case "IOC":
                    oReturn = Expiration.ImmediateOrCancel;
                    break;
            }

            return oReturn;
        }

        #endregion

        #region Status

        public static string ToApiString(this Status value)
        {
            string sReturn = "";

            switch(value)
            {
                case Status.Cancelled:
                    sReturn = "CANCELLED";
                    break;
                case Status.Filled:
                    sReturn = "FILLED";
                    break;
                case Status.New:
                    sReturn = "NEW";
                    break;
                case Status.PartiallyFilled:
                    sReturn = "PARTIALLY_FILLED";
                    break;
                case Status.PendingCancel:
                    sReturn = "PENDING_CANCEL";
                    break;
                case Status.PendingNew:
                    sReturn = "PENDING_NEW";
                    break;
                case Status.Rejected:
                    sReturn = "REJECTED";
                    break;
            }

            return sReturn;
        }

        public static Status StatusFromApiString(string value)
        {
            Status oStatus = Status.Filled;

            switch (value)
            {
                case "NEW": oStatus = Status.New; break;
                case "PENDING_NEW": oStatus = Status.PendingNew; break;
                case "REJECTED": oStatus = Status.Rejected; break;
                case "CANCELLED": oStatus = Status.Cancelled; break;
                case "PENDING_CANCEL": oStatus = Status.PendingCancel; break;
                case "PARTIALLY_FILLED": oStatus = Status.PartiallyFilled; break;
                case "FILLED": oStatus = Status.Filled; break;
            }

            return oStatus;
        }

        #endregion
    }

    #endregion

    #region JSON serialization

    internal class TypeJsonSerializer : EnumJsonSerializer<Type>
    {
        protected override string ToString(Type enumValue)
        {
            return enumValue.ToApiString();
        }

        protected override Type FromString(string enumString)
        {
            return EnumsToApiStrings.TypeFromApiString(enumString);
        }
    }

    internal class SideJsonSerializer : EnumJsonSerializer<Side>
    {
        protected override string ToString(Side enumValue)
        {
            return enumValue.ToApiString();
        }

        protected override Side FromString(string enumString)
        {
            return EnumsToApiStrings.SideFromApiString(enumString);
        }
    }

    internal class ExpirationJsonSerializer : EnumJsonSerializer<Expiration>
    {
        protected override string ToString(Expiration enumValue)
        {
            return enumValue.ToApiString();
        }

        protected override Expiration FromString(string enumString)
        {
            return EnumsToApiStrings.ExpirationFromApiString(enumString);
        }
    }

    internal class StatusJsonSerializer : EnumJsonSerializer<Status>
    {
        protected override string ToString(Status enumValue)
        {
            return enumValue.ToApiString();
        }

        protected override Status FromString(string enumString)
        {
            return EnumsToApiStrings.StatusFromApiString(enumString);
        }
    }

    #endregion
}
