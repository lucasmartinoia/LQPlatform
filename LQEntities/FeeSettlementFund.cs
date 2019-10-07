using Microsoft.EntityFrameworkCore;
using System;

namespace INOM.Entities
{
    public class FeeSettlementFund : FeeSettlement
    {
        public int FundID { get; set; }

        public static void Save(FeeSettlementFund feeSettlementFund)
        {
            using (var db = new DBContext())
            {
                feeSettlementFund.LastUpdate = DateTime.Now;
                db.FeeSettlementFund.Add(feeSettlementFund);
                db.SaveChanges();
            }
        }
        public static void Update(FeeSettlementFund feeSettlementFund)
        {
            using (var db = new DBContext())
            {
                feeSettlementFund.LastUpdate = DateTime.Now;
                db.FeeSettlementFund.Attach(feeSettlementFund);
                db.Entry(feeSettlementFund).Property(x => x.Status).IsModified = true;
                db.Entry(feeSettlementFund).Property(x => x.BackOfficeCommStatus).IsModified = true;
                db.Entry(feeSettlementFund).Property(x => x.BackOfficeFeeTransferID).IsModified = true;
                db.SaveChanges();
            }
        }
        public static void UpdateAll(FeeSettlementFund feeSettlementFund)
        {
            using (var db = new DBContext())
            {
                feeSettlementFund.LastUpdate = DateTime.Now;
                db.FeeSettlementFund.Attach(feeSettlementFund);
                db.Entry(feeSettlementFund).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static void UpdateBackOfficeCommStatus(FeeSettlementFund feeSettlementFund)
        {
            using (var db = new DBContext())
            {
                feeSettlementFund.LastUpdate = DateTime.Now;
                db.Entry(feeSettlementFund).Property(x => x.BackOfficeCommStatus).IsModified = true;
                db.Entry(feeSettlementFund).Property(x => x.LastUpdate).IsModified = true;
                db.SaveChanges();
            }
        }

    }
}
