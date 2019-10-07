using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace INOM.Entities
{
    public class InstructionFundsAmendOrder : Instruction
    {
        public static void Save(InstructionFundsAmendOrder instructionFund)
        {
            using (var db = new DBContext())
            {
                db.InstructionFundsAmendOrders.Add(instructionFund);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Order ID affected. 
        /// </summary>
        public int OrderID { get; set; }

        public static List<InstructionFundsAmendOrder> GetAll()
        {
            using (var db = new DBContext())
            {
                return (from data in db.InstructionFundsAmendOrders select data).ToList();
            }
        }
        public static void Update(InstructionFundsAmendOrder instructionFund)
        {
            using (var db = new DBContext())
            {
                db.InstructionFundsAmendOrders.Attach(instructionFund);
                db.Entry(instructionFund).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
