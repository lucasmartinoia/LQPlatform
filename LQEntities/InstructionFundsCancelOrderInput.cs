namespace INOM.Entities
{
    public class InstructionFundsCancelOrderInput : Instruction
    {
        /// <summary>
        /// BGBAHeader. 
        /// </summary>
        public BGBAHeader BGBAHeader { get; set; }
         /// <summary>
         /// Order ID affected. 
         /// </summary>
         public int OrderID { get; set; }
    }
}
