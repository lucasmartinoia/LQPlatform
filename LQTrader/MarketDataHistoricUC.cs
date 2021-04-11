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
    public partial class MarketDataHistoricUC : UserControl
    {
        public MarketDataHistoricUC()
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
                    txtSymbol.Text = frmInstrumentSelect.SelectedInstrument.Symbol;

                    if (txtSymbol.Text.StartsWith("MERV") == true)
                    {
                        txtMarketID.Text = "MERV";
                        chkExternal.Checked = true;
                    }
                    else
                    {
                        txtMarketID.Text = frmInstrumentSelect.SelectedInstrument.MarketID;
                        chkExternal.Checked = false;
                    }
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
                List<ModelViews.MarketDataHistoric> colHistoric = ModelViews.MarketDataHistoric.GetMarketDataHistoric(txtMarketID.Text, txtSymbol.Text,dtFrom.Value,dtTo.Value,chkExternal.Checked,txtEnvironment.Text);

                if (colHistoric != null)
                {
                    // Main info
                    this.grdInfo.DataSource = colHistoric;
                    this.grdInfo.Update();
                    this.grdvInfo.RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateSearch()
        {
            if (String.IsNullOrEmpty(txtSymbol.Text) == true)
                throw new Exception("Please select an instrument");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = txtExportPath.Text;
            this.grdInfo.ExportToXlsx(path);
        }
    }
}
