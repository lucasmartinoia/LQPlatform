using System.Collections.Generic;

namespace INOM.Entities
{
    public class MonitorServiceAllResponse
    {
        public string Status { get; set; }
        public Dictionary<string, MonitorServiceResponse> Servers { get; set; }
        public List<ErrorLog> ErrorLogs { get; set; }
        public List<PendingOrder> PendingOrders { get; set; }

        public MonitorServiceAllResponse()
        {
            Servers = new Dictionary<string, MonitorServiceResponse>();
            ErrorLogs = new List<ErrorLog>();
            PendingOrders = new List<PendingOrder>();
        }
    }
}
