using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class InstructionResult
    {
        [Key]
        public int InstructionID { get; set; }
        public string BrokerID { get; set; }
        public string ChannelID { get; set; }
        public string ClientID { get; set; }
        public string Comments { get; set; }
        public string Discriminator { get; set; }
        public DateTime? InstructionDateTime { get; set; }
        public DateTime? InstructionExecutionDateTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string OperatorID { get; set; }
        public int? OrdersCount { get; set; }
        public int? ParentInstructionID { get; set; }
        public bool Scheduled { get; set; }
        public string Status { get; set; }
        public int? OrderID { get; set; }
        public string CustodyAccountNo { get; set; }
        public int? TargetFundID { get; set; }
        public string TargetFundParentName { get; set; }
    }
}
