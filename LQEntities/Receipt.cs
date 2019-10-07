using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class Receipt
    {
        [Key]
        public int ReceiptID { get; set; }

        public int? OrderID { get; set; }

        public virtual Order Order { get; set; }

        public int? InstructionID { get; set; }

        public virtual Instruction Instruction { get; set; }

        public string StorageID { get; set; }

        [StringLength(500)]
        public string Link { get; set; }

        public DateTime SetupDateTime { get; set; }
        public string ReceiptType { get; set; }

        public static void Save(Receipt receipt)
        {
            using (var db = new DBContext())
            {
                db.Receipts.Add(receipt);
                db.SaveChanges();
            }
        }

        public static void Update(Receipt receipt)
        {
            using (var db = new DBContext())
            {
                db.Receipts.Attach(receipt);
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
