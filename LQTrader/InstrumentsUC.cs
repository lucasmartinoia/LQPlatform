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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


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
            try
            {
                gridControl1.DataSource = ModelViews.InstrumentDetail.colInstrumentDetails;
                gridControl1.Update();
                gridView1.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                gridControl1.DataSource = ModelViews.InstrumentDetail.GetInstrumentsDetails();
                gridControl1.Update();
                gridView1.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DXMouseEventArgs args = (e as DXMouseEventArgs);
                GridView view = sender as GridView;
                GridHitInfo grdHitInfo = view.CalcHitInfo(args.Location);

                if (grdHitInfo.InRow)
                {
                    ModelViews.Instrument rowUserRecord = gridView1.GetFocusedRow() as ModelViews.Instrument;

                    InstrumentDetails frmInstrumentDetails = new InstrumentDetails(rowUserRecord);
                    frmInstrumentDetails.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
