using Newtonsoft.Json.Converters;

namespace LatamQuants.PrimaryAPI.WebSocket.Serialization
{
    internal class DateTimeJsonDeserializer : IsoDateTimeConverter
    {
        public DateTimeJsonDeserializer()
        {
            DateTimeFormat = "yyyyMMdd-HH:mm:ss.fffK";
        }
    }
}
