using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class InstructionToReceipt
    {
        [Key]
        public int InstructionToReceiptID { get; set; }

        public DateTime ExecutionDate { get; set; }
        public int InstructionID { get; set; }

        public virtual Instruction Instruction { get; set; }

        public static void Save(InstructionToReceipt receipt)
        {
            using (var db = new DBContext())
            {
                db.InstructionToReceipts.Add(receipt);
                db.SaveChanges();
            }
        }
        public static void Delete(InstructionToReceipt receipt)
        {
            using (var db = new DBContext())
            {
                db.InstructionToReceipts.Attach(receipt);
                db.Entry(receipt).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public static void Update(InstructionToReceipt receipt)
        {
            using (var db = new DBContext())
            {
                db.InstructionToReceipts.Attach(receipt);
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
