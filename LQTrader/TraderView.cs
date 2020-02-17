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
            this.dockPanel1_Container.Controls.Add(new InstrumentsUC());
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
            bool bResult=RestAPI.RemoveToken();

            txtStatusBar.Caption = "DISCONNECTED";
            cmdConnect.Enabled = true;
            cmdDisconnect.Enabled = false;
        }
    }
}
