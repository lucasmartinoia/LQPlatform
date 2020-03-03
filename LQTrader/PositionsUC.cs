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
    public partial class PositionsUC : UserControl
    {
        public PositionsUC()
        {
            InitializeComponent();
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

            // Load position details
            try
            {
                grdPositions.DataSource = ModelViews.PositionDetail.GetPositionDetails();
                grdPositions.Update();
                grdvPositions.RefreshData();
                txtAccount.Text = LatamQuants.PrimaryAPI.RestAPI.m_account;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
