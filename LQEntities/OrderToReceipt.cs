using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class OrderToReceipt
    {
        [Key]
        public int OrderToReceiptID { get; set; }

        public DateTime ExecutionDate { get; set; }
        public int OrderID { get; set; }

        public virtual Order Order { get; set; }

        public static void Save(OrderToReceipt receipt)
        {
            using (var db = new DBContext())
            {
                db.OrderToReceipts.Add(receipt);
                db.SaveChanges();
            }
        }
        public static void Delete(OrderToReceipt receipt)
        {
            using (var db = new DBContext())
            {
                db.OrderToReceipts.Attach(receipt);
                db.Entry(receipt).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public static void Update(OrderToReceipt receipt)
        {
            using (var db = new DBContext())
            {
                db.OrderToReceipts.Attach(receipt);
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
