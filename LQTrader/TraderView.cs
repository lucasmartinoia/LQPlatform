using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
