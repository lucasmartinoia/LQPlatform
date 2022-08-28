using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LatamQuants.Support;

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
                    this.grdInfo.DataSource = oMarketDataRT.MainInfo;
                    this.grdInfo.Update();
                    this.grdvInfo.RefreshData();

                    // Bids
                    this.grdBids.DataSource = oMarketDataRT.Bids;
                    this.grdBids.Update();
                    this.grdvBids.RefreshData();

                    // Offers
                    this.grdOffers.DataSource = oMarketDataRT.Offers;
                    this.grdOffers.Update();
                    this.grdvOffers.RefreshData();
                }
            }
            catch(Exception ex)
            {
                string sError = "LQTrader.MarketDataUC.cmdSearch_Click()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                LoggingService.Save(EnumLogType.Error, sError);

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
