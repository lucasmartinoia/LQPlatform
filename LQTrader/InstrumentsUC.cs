using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LatamQuants.PrimaryAPI;

namespace LQTrader
{
    public partial class InstrumentsUC : UserControl
    {
        public InstrumentsUC()
        {
            InitializeComponent();
        }

        private void cmdLoadList_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = ModelViews.Instrument.GetInstruments();
            gridControl1.Update();
        }
    }
}
