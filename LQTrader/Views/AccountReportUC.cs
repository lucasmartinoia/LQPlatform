using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LQTrader
{
    public partial class AccountReportUC : UserControl
    {
        public AccountReportUC()
        {
            InitializeComponent();

            this.pnlReport.Visible = false;
            this.lblLastCalculation.Text = "";
        }

        private void cmdAccountReport_Click(object sender, EventArgs e)
        {
            pnlReport.Visible = false;
            lblLastCalculation.Text = "";
            lblAccount.Visible = true;
            txtAccount.Visible = true;
            txtAccount.Text = LatamQuants.PrimaryAPI.RestAPI.m_account;

            // Load Account Report
            try
            {
                ModelViews.AccountReport oData = ModelViews.AccountReport.GetAccountReport();

                // Set main info
                txtMarketMember.Text = oData.Info.MarketMember;
                txtMarketMemberIdentity.Text = oData.Info.MarketMemberIdentity;
                txtCollateral.Text = oData.Info.Collateral.ToString();
                txtCollateralAvailable.Text = oData.Info.CollateralAvailable.ToString();
                txtMargin.Text = oData.Info.Margin.ToString();
                txtMarginOrders.Text = oData.Info.MarginOrders.ToString();
                txtMarginUncovered.Text = oData.Info.MarginUncovered.ToString();
                txtCash.Text = oData.Info.Cash.ToString();
                txtPortfolio.Text = oData.Info.Portfolio.ToString();
                txtDailyDifference.Text = oData.Info.DailyDifference.ToString();

                // Currency Balance grid
                grdCurrencyBalance.DataSource = oData.CurrencyBalances;
                grdCurrencyBalance.Update();
                grdvCurrencyBalance.RefreshData();

                // Position details grid
                grdAccountValue.DataSource = oData.AccountValues;
                grdAccountValue.Update();
                grdvAccountValue.RefreshData();

                pnlReport.Visible = true;
                lblLastCalculation.Text = oData.Info.LastCalculation;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
