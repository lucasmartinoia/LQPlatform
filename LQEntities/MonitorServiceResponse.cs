using System.Collections.Generic;

namespace INOM.Entities
{
    public class MonitorServiceResponse
    {
        public string Status { get; set; }
        public List<MonitorService> Services { get; set; }
        public List<ErrorLog> ErrorLogs { get; set; }
        public List<PendingOrder> PendingOrders { get; set; }
        
        public MonitorServiceResponse()
        {
            Services = new List<MonitorService>();
            ErrorLogs = new List<ErrorLog>();
            PendingOrders = new List<PendingOrder>();
        }
    }
}
