using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    /// <summary>
    /// Liquidación por Rubro Contable
    /// </summary>
    public class SettlementAccountingEntry : Settlement
    {
        public static void Save(SettlementAccountingEntry settlementAccountingEntry)
        {
            using (var db = new DBContext())
            {
                db.SettlementAccountingEntries.Add(settlementAccountingEntry);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Código del rubro
        /// </summary>
        [StringLength(20)]
        public string AccountingEntryCode { get; set; }

        /// <summary>
        /// Centro de costos del rubro
        /// </summary>
        [StringLength(20)]
        public string AccountingEntryCentreCode { get; set; }

        /// <summary>
        /// Moneda correspondiente al rubro contable
        /// </summary>
        [StringLength(5)]
        public string AccountingEntryCurrency { get; set; }
    }
}
