namespace INOM.Entities
{
    public class InstructionOrderPermanent
    { 
        public Scheduler InstructionScheduled { get; set; }
        public OrderFund OrderFund { get; set; }
        public InstructionFundsPermanent InstructionFundsPermanent { get; set; }
    }
}
