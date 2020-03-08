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
                this.T1Available = pT1Available;
                this.T1Consumed = pT1Consumed;
                this.T2Available = pT2Available;
                this.T2Consumed = pT2Consumed;
                this.T3Available = pT3Available;
                this.T3Consumed = pT3Consumed;
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

            public AccountValue(string pItem, double? pT0Total, double? pT0Available, double? pT1Total, double? pT1Available, double? pT2Total, double? pT2Available, double? pT3Total, double? pT3Available)
            {
                this.Item = pItem;
                this.T0Available = pT0Available;
                this.T0Total = pT0Total;
                this.T1Available = pT1Available;
                this.T1Total = pT1Total;
                this.T2Available = pT2Available;
                this.T2Total = pT2Total;
                this.T3Available = pT3Available;
                this.T3Total = pT3Total;
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

            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.AccountValue oT0AccValue = oData.accountData?.detailedAccountReports?.CASH?.accountValue;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.AccountValue oT1AccValue = oData.accountData?.detailedAccountReports?.NEXT_DAY?.accountValue;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.AccountValue oT2AccValue = oData.accountData?.detailedAccountReports?.T_PLUS_2?.accountValue;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.AccountValue oT3AccValue = oData.accountData?.detailedAccountReports?.T_PLUS_3?.accountValue;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.AccountValue oT0AccAvail = oData.accountData?.detailedAccountReports?.CASH?.availableToOperate;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.AccountValue oT1AccAvail = oData.accountData?.detailedAccountReports?.NEXT_DAY?.availableToOperate;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.AccountValue oT2AccAvail = oData.accountData?.detailedAccountReports?.T_PLUS_2?.availableToOperate;
            LatamQuants.PrimaryAPI.Models.getAccountReportResponse.AccountValue oT3AccAvail = oData.accountData?.detailedAccountReports?.T_PLUS_3?.availableToOperate;

            oReturn.AccountValues.Add(new AccountValue("Total Cash", oT0AccValue?.cash?.totalCash, oT0AccAvail?.cash?.totalCash, oT1AccValue?.cash?.totalCash, oT1AccAvail?.cash?.totalCash, oT2AccValue?.cash?.totalCash, oT2AccAvail?.cash?.totalCash, oT3AccValue?.cash?.totalCash, oT3AccAvail?.cash?.totalCash));
            oReturn.AccountValues.Add(new AccountValue("ARS", oT0AccValue?.cash?.detailedCash?.ARS, oT0AccAvail?.cash?.detailedCash?.ARS, oT1AccValue?.cash?.detailedCash?.ARS, oT1AccAvail?.cash?.detailedCash?.ARS, oT2AccValue?.cash?.detailedCash?.ARS, oT2AccAvail?.cash?.detailedCash?.ARS, oT3AccValue?.cash?.detailedCash?.ARS, oT3AccAvail?.cash?.detailedCash?.ARS));
            oReturn.AccountValues.Add(new AccountValue("ARS BCRA", oT0AccValue?.cash?.detailedCash?.ARS_BCRA, oT0AccAvail?.cash?.detailedCash?.ARS_BCRA, oT1AccValue?.cash?.detailedCash?.ARS_BCRA, oT1AccAvail?.cash?.detailedCash?.ARS_BCRA, oT2AccValue?.cash?.detailedCash?.ARS_BCRA, oT2AccAvail?.cash?.detailedCash?.ARS_BCRA, oT3AccValue?.cash?.detailedCash?.ARS_BCRA, oT3AccAvail?.cash?.detailedCash?.ARS_BCRA));
            oReturn.AccountValues.Add(new AccountValue("U$S", oT0AccValue?.cash?.detailedCash?.USS, oT0AccAvail?.cash?.detailedCash?.USS, oT1AccValue?.cash?.detailedCash?.USS, oT1AccAvail?.cash?.detailedCash?.USS, oT2AccValue?.cash?.detailedCash?.USS, oT2AccAvail?.cash?.detailedCash?.USS, oT3AccValue?.cash?.detailedCash?.USS, oT3AccAvail?.cash?.detailedCash?.USS));
            oReturn.AccountValues.Add(new AccountValue("USD C", oT0AccValue?.cash?.detailedCash?.USD_C, oT0AccAvail?.cash?.detailedCash?.USD_C, oT1AccValue?.cash?.detailedCash?.USD_C, oT1AccAvail?.cash?.detailedCash?.USD_C, oT2AccValue?.cash?.detailedCash?.USD_C, oT2AccAvail?.cash?.detailedCash?.USD_C, oT3AccValue?.cash?.detailedCash?.USD_C, oT3AccAvail?.cash?.detailedCash?.USD_C));
            oReturn.AccountValues.Add(new AccountValue("USD D", oT0AccValue?.cash?.detailedCash?.USD_D, oT0AccAvail?.cash?.detailedCash?.USD_D, oT1AccValue?.cash?.detailedCash?.USD_D, oT1AccAvail?.cash?.detailedCash?.USD_D, oT2AccValue?.cash?.detailedCash?.USD_D, oT2AccAvail?.cash?.detailedCash?.USD_D, oT3AccValue?.cash?.detailedCash?.USD_D, oT3AccAvail?.cash?.detailedCash?.USD_D));
            oReturn.AccountValues.Add(new AccountValue("USD G", oT0AccValue?.cash?.detailedCash?.USD_G, oT0AccAvail?.cash?.detailedCash?.USD_G, oT1AccValue?.cash?.detailedCash?.USD_G, oT1AccAvail?.cash?.detailedCash?.USD_G, oT2AccValue?.cash?.detailedCash?.USD_G, oT2AccAvail?.cash?.detailedCash?.USD_G, oT3AccValue?.cash?.detailedCash?.USD_G, oT3AccAvail?.cash?.detailedCash?.USD_G));
            oReturn.AccountValues.Add(new AccountValue("USD R", oT0AccValue?.cash?.detailedCash?.USD_R, oT0AccAvail?.cash?.detailedCash?.USD_R, oT1AccValue?.cash?.detailedCash?.USD_R, oT1AccAvail?.cash?.detailedCash?.USD_R, oT2AccValue?.cash?.detailedCash?.USD_R, oT2AccAvail?.cash?.detailedCash?.USD_R, oT3AccValue?.cash?.detailedCash?.USD_R, oT3AccAvail?.cash?.detailedCash?.USD_R));
            oReturn.AccountValues.Add(new AccountValue("EUR", oT0AccValue?.cash?.detailedCash?.EUR, oT0AccAvail?.cash?.detailedCash?.EUR, oT1AccValue?.cash?.detailedCash?.EUR, oT1AccAvail?.cash?.detailedCash?.EUR, oT2AccValue?.cash?.detailedCash?.EUR, oT2AccAvail?.cash?.detailedCash?.EUR, oT3AccValue?.cash?.detailedCash?.EUR, oT3AccAvail?.cash?.detailedCash?.EUR));
            oReturn.AccountValues.Add(new AccountValue("Movements", oT0AccValue?.movements, oT0AccAvail?.movements, oT1AccValue?.movements, oT1AccAvail?.movements, oT2AccValue?.movements, oT2AccAvail?.movements, oT3AccValue?.movements, oT3AccAvail?.movements));
            oReturn.AccountValues.Add(new AccountValue("Pending Movements", oT0AccValue?.pendingMovements, oT0AccAvail?.pendingMovements, oT1AccValue?.pendingMovements, oT1AccAvail?.pendingMovements, oT2AccValue?.pendingMovements, oT2AccAvail?.pendingMovements, oT3AccValue?.pendingMovements, oT3AccAvail?.pendingMovements));
            oReturn.AccountValues.Add(new AccountValue("Credit", oT0AccValue?.credit, oT0AccAvail?.credit, oT1AccValue?.credit, oT1AccAvail?.credit, oT2AccValue?.credit, oT2AccAvail?.credit, oT3AccValue?.credit, oT3AccAvail?.credit));
            oReturn.AccountValues.Add(new AccountValue("Total", oT0AccValue?.total, oT0AccAvail?.total, oT1AccValue?.total, oT1AccAvail?.total, oT2AccValue?.total, oT2AccAvail?.total, oT3AccValue?.total, oT3AccAvail?.total));

            return oReturn;
        }
    }
}
