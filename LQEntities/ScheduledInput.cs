using System;

namespace INOM.Entities
{

    public class ScheduledOrderPermanentInput
    {
         public int BrokerID { get; set; }
        public string ChannelID { get; set; }
        public string OperatorID { get; set; }
        public string ClientID { get; set; }
        public DateTime InstructionDateTime { get; set; }
        public string Comments { get; set; }
        public Scheduler Scheduler { get; set; }
        public OrderFundInput Order { get; set; }
    }

}
