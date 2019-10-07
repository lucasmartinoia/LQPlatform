namespace INOM.Entities
{
    public class InstructionFundsCancelOrderNumberInput : Instruction
    {
        /// <summary>
        /// BGBAHeader. 
        /// </summary>
        public BGBAHeader BGBAHeader { get; set; }
        /// <summary>
        /// Order Number affected. 
        /// </summary>
        public int OrderNumber { get; set; }
    }
}
