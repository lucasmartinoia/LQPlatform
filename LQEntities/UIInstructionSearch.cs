using System;

namespace INOM.Entities
{
    public class UIInstructionSearch
    {
        //public int InstructionID { get; set; }
        public string brokerID { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? InstruccionIDFrom { get; set; }
        public int? InstruccionIDTo { get; set; }
        public int? InstructionNumber { get; set; }
        public string channelID { get; set; }
        public string ClientID { get; set; }
        public string discriminator { get; set; }
        public string operatorID { get; set; }
        public string status { get; set; }
        public int orderID { get; set; }
        public string CustodyAccountNo { get; set; }
        //public string ProductType { get; set; }
    }
}
