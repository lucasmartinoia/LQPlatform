using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;

namespace LQTrader
{
    public partial class PositionsUC : UserControl
    {
        public PositionsUC()
        {
            InitializeComponent();

            grdvPositionDetails.OptionsFilter.AllowFilterEditor = false;
            grdvPositionDetails.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            grdvPositionsD.OptionsFilter.AllowFilterEditor = false;
            grdvPositionsD.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            grdvPositionsSDDailyDiff.OptionsFilter.AllowFilterEditor = false;
            grdvPositionsSDDailyDiff.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            lblTitle.Visible = false;
            pnlPositions.Visible = false;
            pnlPositionDetails.Visible = false;
            
        }

        private void PositionsUC_Load(object sender, EventArgs e)
        {

        }

        private void pnlPositionDetailsTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdPositions_Click(object sender, EventArgs e)
        {
            pnlPositionDetails.Visible = false;
            pnlPositionDetails.Dock = DockStyle.None;
            pnlPositions.Visible = true;
            pnlPositions.Dock = DockStyle.Fill;
            lblTitle.Text = "POSITIONS";
            lblTitle.Visible = true;

            // Load positions
            try
            {
                grdPositions.DataSource = ModelViews.Position.GetPositions();
                grdPositions.Update();
                grdvPositions.RefreshData();
                txtAccount.Text = LatamQuants.PrimaryAPI.RestAPI.m_account;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdPositionDetails_Click(object sender, EventArgs e)
        {
            pnlPositions.Visible = false;
            pnlPositions.Dock = DockStyle.None;
            pnlPositionDetails.Visible = true;
            pnlPositionDetails.Dock = DockStyle.Fill;
            lblTitle.Text = "POSITION DETAILS";
            lblTitle.Visible = true;

            // Load position details
            try
            {
                ModelViews.PositionDetailMain oData= ModelViews.PositionDetailMain.GetPositionDetails();

                // Set account name and main info
                txtAccount.Text = LatamQuants.PrimaryAPI.RestAPI.m_account;
                txtTotalDailyDifference.Text = oData.Details.TotalDailyDiffPlain.ToString();
                txtTotalMarketValue.Text = oData.Details.TotalMarketValue.ToString();
                lblLastCalculation.Text = oData.Details.LastCalculation;

                // Positions grid
                grdPositionsD.DataSource = oData.Positions;
                grdPositionsD.Update();
                grdvPositionsD.RefreshData();

                // Position details grid
                grdPositionDetails.DataSource = oData.PositionDetails;
                grdPositionDetails.Update();
                grdvPositionDetails.RefreshData();

                // Daily Difference grid
                grdPositionsSDDailyDiff.DataSource = oData.PositionDetailDailyDifferences;
                grdPositionsSDDailyDiff.Update();
                grdvPositionsSDDailyDiff.RefreshData();

                ShowPositionDetails(0);
                //if(oData.PositionDetails.Count>0)
                //{
                //    grdvPositionsSDDailyDiff.ActiveFilterCriteria = new DevExpress.Data.Filtering.BinaryOperator("Id", oData.PositionDetails.First().Id, BinaryOperatorType.Equal);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdvPositionsD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            // Filter position details and daily difference grids
            ShowPositionDetails(e.FocusedRowHandle);
        }

        private void ShowPositionDetails(int pRowHandle)
        {
            //if (pRowHandle == 0) return;
            // Filter Position details grid
            ModelViews.PositionDetailMain.Position oPosition = (ModelViews.PositionDetailMain.Position)grdvPositionsD.GetRow(pRowHandle);
            if (oPosition != null)
            {
                grdvPositionDetails.ActiveFilterCriteria = new DevExpress.Data.Filtering.BinaryOperator("SymbolReference", oPosition.SymbolReference, BinaryOperatorType.Equal);
                ShowPositionDailyDiff(grdvPositionDetails.TopRowIndex);
            }
        }

        private void ShowPositionDailyDiff(int pRowHandle)
        {
            ModelViews.PositionDetailMain.PositionDetail oPositionDetail = (ModelViews.PositionDetailMain.PositionDetail)grdvPositionDetails.GetRow(pRowHandle);

            if (oPositionDetail != null && grdPositionsSDDailyDiff.DataSource != null)
                grdvPositionsSDDailyDiff.ActiveFilterCriteria = new DevExpress.Data.Filtering.BinaryOperator("Id", oPositionDetail.Id, BinaryOperatorType.Equal);
        }

        private void grdvPositionDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            // Filter position details and daily difference grids
            ShowPositionDailyDiff(e.FocusedRowHandle);
        }
    }
}
