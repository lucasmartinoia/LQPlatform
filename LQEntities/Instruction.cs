using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public abstract class Instruction
    {
        /// <summary>
        /// Instruction ID.
        /// </summary>
        [Key]
        public int InstructionID { get; set; }

        public int? InstructionNumber { get; set; }
        /// <summary>
        /// Broker.
        /// </summary>
        [Required]
        //   public Broker Broker { get; set; }
        public string BrokerID { get; set; }
        public virtual Broker Broker { get; set; }

        /// <summary>
        /// Broker channel: to identify where the order was inputed.
        /// </summary>
        [StringLength(50)]
        public string ChannelID { get; set; }
        
        /// <summary>
        /// Broker operator: order input user.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string OperatorID { get; set; }
        
        /// <summary>
        /// Client who has required the order.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ClientID { get; set; }
        
        /// <summary>
        /// Input instruction date and time.
        /// </summary>
        public DateTime InstructionDateTime { get; set; }

        /// <summary>
        /// Instruction execution date and time.
        /// </summary>
        public DateTime InstructionExecutionDateTime { get; set; }

        /// <summary>
        /// Date and time of last order update.
        /// </summary>
        public DateTime LastUpdate { get; set; }
        
        /// <summary>
        /// Order comments.
        /// </summary>
        [StringLength(200)]
        public string Comments { get; set; }
        
        /// <summary>
        /// Order Status: P = Pending completion, A = Canceled, C = Completed, E = Error.
        /// </summary>
        [StringLength(1)]
        public string Status { get; set; }

        /// <summary>
        /// Indicates if the instruction is to be executed today or in the future.
        /// </summary>
        public bool Scheduled { get; set; }

        public int ParentInstructionID { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<CalypsoResponse> CalypsoResponses { get; set; }
        /// <summary>
        /// Receipts related to this order.
        /// </summary>
        public virtual List<Receipt> Receipts { get; set; }

        public int TypeTransfer { get; set; }

        //  public virtual List<Scheduler> InstructionScheduled { get; set; }

        /// <summary>
        /// Number of orders related to this instruction.
        /// </summary>
        public int OrdersCount { get; set; }
        public static void Update(Instruction instructionFund)
        {
            using (var db = new DBContext())
            {
                db.Instructions.Attach(instructionFund);
                db.Entry(instructionFund).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static decimal ValorizeTenancy(Instruction instructionPromote, string excludeFundID)
        {
            decimal amount = 0.00M;

            foreach (OrderFund order in instructionPromote.Orders)
            {
                if (order.Status == "C" && order.OrderType == "R" && order.FundID != excludeFundID)
                {
                    // Get Instrument from CalypsoInstrument
                    CalypsoInstrument calypsoInstrument = CalypsoInstrument.GetCalypsoInstrument(int.Parse(order.FundID));
                    amount = amount + (decimal.Parse(calypsoInstrument.Precio) * order.Shares ?? 0);
                }
            }
            return amount;
        }

        public static decimal CalculateShare(Instruction instructionFundsTransferFund)
        {
            var originAmount = ((InstructionFundsTransferFund)instructionFundsTransferFund).OriginAmount;
            CalypsoInstrument calypsoInstrument = CalypsoInstrument.GetCalypsoInstrument(((InstructionFundsTransferFund)instructionFundsTransferFund).OriginFundID);
            return (decimal.Parse(calypsoInstrument.Precio) / originAmount);
        }

        public int GetTypeTransfer()
        {
            return 0;
        }
    }
}
