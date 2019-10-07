using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class SettlementSap:Settlement
    {
        public static void Save(SettlementSap settlementSap)
        {
            using (var db = new DBContext())
            {
                db.SettlementSaps.Add(settlementSap);
                db.SaveChanges();
            }
        }
        [StringLength(30)]
        public string SapMonetaryAccountNo { get; set; }
        public string SapMonetaryAccountType { get; set; }
        public string SapMonetaryAccountOffice { get; set; }
        public string SapMonetaryAccountCurrency { get; set; }
        public decimal SapMonetaryAccountAmount { get; set; }
        public string SapBankCountry { get; set; }
        public string SapBankKey { get; set; }
        public string SapCurrencyCodeListAgencyID { get; set; }
        public string SapCurrencyCodeListId { get; set; }
        public string SapBakendID { get; set; }
        public string SapSchemeID { get; set; }
        public string SapSchemeAgencyID { get; set; }
        public string SapPrenoteTypeCode { get; set; }
    }
}
