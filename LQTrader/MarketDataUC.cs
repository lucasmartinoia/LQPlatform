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
    public partial class MarketDataUC : UserControl
    {
        public MarketDataUC()
        {
            InitializeComponent();
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            try
            {
                InstrumentSelect frmInstrumentSelect = new InstrumentSelect();
                frmInstrumentSelect.ShowDialog();

                if (frmInstrumentSelect.SelectedInstrument != null)
                {
                    txtMarketID.Text = frmInstrumentSelect.SelectedInstrument.MarketID;
                    txtSymbol.Text = frmInstrumentSelect.SelectedInstrument.Symbol;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();
                ModelViews.MarketDataRT oMarketDataRT = ModelViews.MarketDataRT.GetMarketDataRT(txtMarketID.Text, txtSymbol.Text, (int)txtDepth.Value);

                if(oMarketDataRT!=null)
                {
                    // Main info
                    this.pnlMD.Controls["grdMD"]   gridControl1.DataSource = ModelViews.Order.UpdateOrders(null, ModelViews.Order.eUpdateOrdersMode.ByAccount);
                    gridControl1.Update();
                    gridView1.RefreshData();


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateSearch()
        {
            if (String.IsNullOrEmpty(txtSymbol.Text) == true)
                throw new Exception("Please select an instrument");
        }
    }
}
