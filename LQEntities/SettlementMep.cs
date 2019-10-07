using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class SettlementMep : Settlement
    {
        public static void Save(SettlementMep settlementMep)
        {
            using (var db = new DBContext())
            {
                db.SettlementMeps.Add(settlementMep);
                db.SaveChanges();
            }
        }
        public string MepCUIT { get; set; }
        /// <summary>
        /// CBU is used for MEP settlement method.
        /// </summary>
        public string MepCBU { get; set; }

        [StringLength(30)]
        public string MepIssuerBankID { get; set; }
    }
}
