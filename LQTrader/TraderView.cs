using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LatamQuants.PrimaryAPI;

namespace LQTrader
{
    public partial class TraderView : Form
    {
        public TraderView()
        {
            InitializeComponent();

            
            // Handling the QueryControl event that will populate all automatically generated Documents
            
            this.tabbedView1.QueryControl += tabbedView1_QueryControl;

            InstrumentsUC oInstrumentsUC = new InstrumentsUC();
            oInstrumentsUC.Dock = DockStyle.Fill;
            this.dockPanel1_Container.Controls.Add(oInstrumentsUC);

            BlotterUC oBlotterUC = new BlotterUC();
            oBlotterUC.Dock = DockStyle.Fill;
            this.dockPanel7_Container.Controls.Add(oBlotterUC);

            MarketDataUC oMarketDataUD = new MarketDataUC();
            oMarketDataUD.Dock = DockStyle.Fill;
            this.dockPanel2_Container.Controls.Add(oMarketDataUD);

            MarketDataHistoricUC oMarketDataHistoricUC = new MarketDataHistoricUC();
            oMarketDataHistoricUC.Dock = DockStyle.Fill;
            this.dockPanel5_Container.Controls.Add(oMarketDataHistoricUC);

            PositionsUC oPositionsUC = new PositionsUC();
            oPositionsUC.Dock = DockStyle.Fill;
            this.dockPanel6_Container.Controls.Add(oPositionsUC);

            AccountReportUC oAccountReportUC = new AccountReportUC();
            oAccountReportUC.Dock = DockStyle.Fill;
            this.controlContainer1.Controls.Add(oAccountReportUC);
        }

        // Assigning a required content for each auto generated Document
        void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.ShowDialog();

            if(frmLogin.Connected==true)
            {
                txtStatusBar.Caption = "CONNECTED";
                cmdConnect.Enabled = false;
                cmdDisconnect.Enabled = true;

           }
            else
            {
                txtStatusBar.Caption = "DISCONNECTED";
                cmdConnect.Enabled = true;
                cmdDisconnect.Enabled = false;
            }

            frmLogin.Dispose();
        }

        private void cmdDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool bResult = RestAPI.RemoveToken();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtStatusBar.Caption = "DISCONNECTED";
            cmdConnect.Enabled = true;
            cmdDisconnect.Enabled = false;
        }

        private void hideContainerLeft_Click(object sender, EventArgs e)
        {

        }
    }
}
