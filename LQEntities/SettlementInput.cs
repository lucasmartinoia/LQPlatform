namespace INOM.Entities
{
    public class SettlementInput
    {
        public string SettlementMethod { get; set; }
        public string Destination { get; set; }

        //////////////////////////////////////////////////////////////////////
        // Settlement Mep
        //////////////////////////////////////////////////////////////////////
        public string MepCUIT { get; set; }
        public string MepCBU { get; set; }
        public string MepIssuerBankID { get; set; }

        //////////////////////////////////////////////////////////////////////
        // Settlement Sap
        //////////////////////////////////////////////////////////////////////
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

        //////////////////////////////////////////////////////////////////////
        // Settlement Swift
        //////////////////////////////////////////////////////////////////////
        public string SwiftBIC { get; set; }

        //////////////////////////////////////////////////////////////////////
        // Settlement Accounting Entry
        //////////////////////////////////////////////////////////////////////
        public string AccountingEntryCode { get; set; }
        public string AccountingEntryCentreCode { get; set; }
        public string AccountingEntryCurrency { get; set; }
    }
}
