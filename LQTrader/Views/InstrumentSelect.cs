using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class InstrumentSelect : Form
    {
        public ModelViews.Instrument SelectedInstrument { get; private set; }

        public InstrumentSelect(List<ModelViews.Instrument> pcolInstruments=null)
        {
            InitializeComponent();

            if(pcolInstruments is null || pcolInstruments.Count==0)
            {
                // Load instruments
                gridControl1.DataSource = ModelViews.Instrument.GetInstruments();
                gridControl1.Update();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs args = (e as DXMouseEventArgs);
            GridView view = sender as GridView;
            GridHitInfo grdHitInfo = view.CalcHitInfo(args.Location);

            if (grdHitInfo.InRow)
            {
                ModelViews.Instrument oInstrument = gridView1.GetFocusedRow() as ModelViews.Instrument;

                this.SelectedInstrument = oInstrument;
                this.Close();
            }
        }
    }
}
