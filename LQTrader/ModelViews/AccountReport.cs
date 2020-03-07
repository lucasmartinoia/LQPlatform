using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatamQuants.PrimaryAPI;

namespace LQTrader.ModelViews
{
    public class AccountReport
    {
        public MainInfo Info { get; set; }
        public List<CurrencyBalance> CurrencyBalances { get; set; }
        public List<AccountValue> AccountValues { get; set; }


        public class MainInfo
        {
            public string Account { get; set; }
            public string LastCalculation { get; set; }
            public string MarketMember { get; set; }
            public string MarketMemberIdentity { get; set; }
            public double Collateral { get; set; }
            public double CollateralAvailable { get; set; }
            public double Margin { get; set; }
            public double MarginOrders { get; set; }
            public double MarginUncovered { get; set; }
            public double Cash { get; set; }
            public double Portfolio { get; set; }
            public double DailyDifference { get; set; }
        }

        public class CurrencyBalance
        {
            public string Currency { get; set; }
            public double? T0Consumed { get; set; }
            public double? T0Available { get; set; }
            public double? T1Consumed { get; set; }
            public double? T1Available { get; set; }
            public double? T2Consumed { get; set; }
            public double? T2Available { get; set; }
            public double? T3Consumed { get; set; }
            public double? T3Available { get; set; }

            public CurrencyBalance(string pCurrency, double? pT0Consumed, double? pT0Available, double? pT1Consumed, double? pT1Available, double? pT2Consumed, double? pT2Available, double? pT3Consumed, double? pT3Available)
            {
                this.Currency = pCurrency;
                this.T0Available = pT0Available;
                this.T0Consumed = pT0Consumed;
                this.T1Available = pT0Available;
                this.T1Consumed = pT0Consumed;
                this.T2Available = pT0Available;
                this.T2Consumed = pT0Consumed;
                this.T3Available = pT0Available;
                this.T3Consumed = pT0Consumed;
            }
        }

        public class AccountValue
        {
            public string Item { get; set; }
            public double? T0Total { get; set; }
            public double? T0Available { get; set; }
            public double? T1Total { get; set; }
            public double? T1Available { get; set; }
            public double? T2Total { get; set; }
            public double? T2Available { get; set; }
            public double? T3Total { get; set; }
            public double? T3Available { get; set; }

            public AccountValue(string pItem, double pT0Total, double pT0Available, double pT1Total, double pT1Available, double pT2Total, double pT2Available, double pT3Total, double pT3Available)
            {
                this.Item = pItem;
                this.T0Available = pT0Available;
                this.T0Total = pT0Total;
                this.T1Available = pT0Available;
                this.T1Total = pT0Total;
                this.T2Available = pT0Available;
                this.T2Total = pT0Total;
                this.T3Available = pT0Available;
                this.T3Total = pT0Total;
            }
        }

        public static AccountReport GetAccountReport()
        {
            ModelViews.AccountReport oReturn = new ModelViews.AccountReport();
            oReturn.AccountValues = new List<AccountValue>();
            oReturn.CurrencyBalances = new List<CurrencyBalance>();
            oReturn.Info = new MainInfo();

            // Get account report
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.RootObject oData=RestAPI.GetAccountReport();

            // Parse main info
            Service.mapper.Map<LatamQuants.PrimaryAPI.Models.getAccountReportResponse.AccountData, ModelViews.AccountReport.MainInfo>(oData.accountData, oReturn.Info);

            // Parse currency balances

            // ARS
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.CurrencyDetailedBalance oCBT0 = oData.accountData?.detailedAccountReports?.CASH?.currencyBalance?.detailedCurrencyBalance?.ARS;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.CurrencyDetailedBalance oCBT1 = oData.accountData?.detailedAccountReports?.NEXT_DAY?.currencyBalance?.detailedCurrencyBalance?.ARS;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.CurrencyDetailedBalance oCBT2 = oData.accountData?.detailedAccountReports?.T_PLUS_2?.currencyBalance?.detailedCurrencyBalance?.ARS;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.CurrencyDetailedBalance oCBT3 = oData.accountData?.detailedAccountReports?.T_PLUS_3?.currencyBalance?.detailedCurrencyBalance?.ARS;
            oReturn.CurrencyBalances.Add(new CurrencyBalance("ARS", oCBT0?.consumed, oCBT0?.available, oCBT1?.consumed, oCBT1?.available, oCBT2?.consumed, oCBT2?.available, oCBT3?.consumed, oCBT3?.available));

            // ARS_BCRA
            oCBT0 = oData.accountData?.detailedAccountReports?.CASH?.currencyBalance?.detailedCurrencyBalance?.ARS_BCRA;
            oCBT1 = oData.accountData?.detailedAccountReports?.NEXT_DAY?.currencyBalance?.detailedCurrencyBalance?.ARS_BCRA;
            oCBT2 = oData.accountData?.detailedAccountReports?.T_PLUS_2?.currencyBalance?.detailedCurrencyBalance?.ARS_BCRA;
            oCBT3 = oData.accountData?.detailedAccountReports?.T_PLUS_3?.currencyBalance?.detailedCurrencyBalance?.ARS_BCRA;
            oReturn.CurrencyBalances.Add(new CurrencyBalance("ARS BCRA", oCBT0?.consumed, oCBT0?.available, oCBT1?.consumed, oCBT1?.available, oCBT2?.consumed, oCBT2?.available, oCBT3?.consumed, oCBT3?.available));

            // EUR
            oCBT0 = oData.accountData?.detailedAccountReports?.CASH?.currencyBalance?.detailedCurrencyBalance?.EUR;
            oCBT1 = oData.accountData?.detailedAccountReports?.NEXT_DAY?.currencyBalance?.detailedCurrencyBalance?.EUR;
            oCBT2 = oData.accountData?.detailedAccountReports?.T_PLUS_2?.currencyBalance?.detailedCurrencyBalance?.EUR;
            oCBT3 = oData.accountData?.detailedAccountReports?.T_PLUS_3?.currencyBalance?.detailedCurrencyBalance?.EUR;
            oReturn.CurrencyBalances.Add(new CurrencyBalance("EUR", oCBT0?.consumed, oCBT0?.available, oCBT1?.consumed, oCBT1?.available, oCBT2?.consumed, oCBT2?.available, oCBT3?.consumed, oCBT3?.available));

            // USS
            oCBT0 = oData.accountData?.detailedAccountReports?.CASH?.currencyBalance?.detailedCurrencyBalance?.USS;
            oCBT1 = oData.accountData?.detailedAccountReports?.NEXT_DAY?.currencyBalance?.detailedCurrencyBalance?.USS;
            oCBT2 = oData.accountData?.detailedAccountReports?.T_PLUS_2?.currencyBalance?.detailedCurrencyBalance?.USS;
            oCBT3 = oData.accountData?.detailedAccountReports?.T_PLUS_3?.currencyBalance?.detailedCurrencyBalance?.USS;
            oReturn.CurrencyBalances.Add(new CurrencyBalance("USS", oCBT0?.consumed, oCBT0?.available, oCBT1?.consumed, oCBT1?.available, oCBT2?.consumed, oCBT2?.available, oCBT3?.consumed, oCBT3?.available));

            // USD_C
            oCBT0 = oData.accountData?.detailedAccountReports?.CASH?.currencyBalance?.detailedCurrencyBalance?.USD_C;
            oCBT1 = oData.accountData?.detailedAccountReports?.NEXT_DAY?.currencyBalance?.detailedCurrencyBalance?.USD_C;
            oCBT2 = oData.accountData?.detailedAccountReports?.T_PLUS_2?.currencyBalance?.detailedCurrencyBalance?.USD_C;
            oCBT3 = oData.accountData?.detailedAccountReports?.T_PLUS_3?.currencyBalance?.detailedCurrencyBalance?.USD_C;
            oReturn.CurrencyBalances.Add(new CurrencyBalance("USD C", oCBT0?.consumed, oCBT0?.available, oCBT1?.consumed, oCBT1?.available, oCBT2?.consumed, oCBT2?.available, oCBT3?.consumed, oCBT3?.available));

            // USD_D
            oCBT0 = oData.accountData?.detailedAccountReports?.CASH?.currencyBalance?.detailedCurrencyBalance?.USD_D;
            oCBT1 = oData.accountData?.detailedAccountReports?.NEXT_DAY?.currencyBalance?.detailedCurrencyBalance?.USD_D;
            oCBT2 = oData.accountData?.detailedAccountReports?.T_PLUS_2?.currencyBalance?.detailedCurrencyBalance?.USD_D;
            oCBT3 = oData.accountData?.detailedAccountReports?.T_PLUS_3?.currencyBalance?.detailedCurrencyBalance?.USD_D;
            oReturn.CurrencyBalances.Add(new CurrencyBalance("USD D", oCBT0?.consumed, oCBT0?.available, oCBT1?.consumed, oCBT1?.available, oCBT2?.consumed, oCBT2?.available, oCBT3?.consumed, oCBT3?.available));

            // USD_G
            oCBT0 = oData.accountData?.detailedAccountReports?.CASH?.currencyBalance?.detailedCurrencyBalance?.USD_G;
            oCBT1 = oData.accountData?.detailedAccountReports?.NEXT_DAY?.currencyBalance?.detailedCurrencyBalance?.USD_G;
            oCBT2 = oData.accountData?.detailedAccountReports?.T_PLUS_2?.currencyBalance?.detailedCurrencyBalance?.USD_G;
            oCBT3 = oData.accountData?.detailedAccountReports?.T_PLUS_3?.currencyBalance?.detailedCurrencyBalance?.USD_G;
            oReturn.CurrencyBalances.Add(new CurrencyBalance("USD G", oCBT0?.consumed, oCBT0?.available, oCBT1?.consumed, oCBT1?.available, oCBT2?.consumed, oCBT2?.available, oCBT3?.consumed, oCBT3?.available));

            // USD_R
            oCBT0 = oData.accountData?.detailedAccountReports?.CASH?.currencyBalance?.detailedCurrencyBalance?.USD_R;
            oCBT1 = oData.accountData?.detailedAccountReports?.NEXT_DAY?.currencyBalance?.detailedCurrencyBalance?.USD_R;
            oCBT2 = oData.accountData?.detailedAccountReports?.T_PLUS_2?.currencyBalance?.detailedCurrencyBalance?.USD_R;
            oCBT3 = oData.accountData?.detailedAccountReports?.T_PLUS_3?.currencyBalance?.detailedCurrencyBalance?.USD_R;
            oReturn.CurrencyBalances.Add(new CurrencyBalance("USD R", oCBT0?.consumed, oCBT0?.available, oCBT1?.consumed, oCBT1?.available, oCBT2?.consumed, oCBT2?.available, oCBT3?.consumed, oCBT3?.available));

            // Parse account values

            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.Cash oCashT0 = oData.accountData?.detailedAccountReports?.CASH?.accountValue?.cash;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.Cash oCashT1 = oData.accountData?.detailedAccountReports?.NEXT_DAY?.accountValue?.cash;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.Cash oCashT2 = oData.accountData?.detailedAccountReports?.T_PLUS_2?.accountValue?.cash;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.Cash oCashT3 = oData.accountData?.detailedAccountReports?.T_PLUS_3?.accountValue?.cash;
            oReturn.AccountValues.Add(new AccountValue("Total Cash", oCashT0?.consumed, oCBT0?.available, oCBT1?.consumed, oCBT1?.available, oCBT2?.consumed, oCBT2?.available, oCBT3?.consumed, oCBT3?.available));


            return oReturn;
        }
    }
}
