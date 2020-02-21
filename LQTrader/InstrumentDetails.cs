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
    public partial class InstrumentDetails : Form
    {
        public InstrumentDetails(ModelViews.Instrument pInstrument)
        {
            InitializeComponent();

            lblInstrumentName.Text = pInstrument.Symbol;

            LatamQuants.PrimaryAPI.Models.InstrumentDetails  oInstrumentDetails = RestAPI.GetOneInstrumentDetails(pInstrument.MarketID, pInstrument.Symbol).instrument;

            ModelViews.InstrumentDetail vInstrumentDetails = new ModelViews.InstrumentDetail();
            Service.mapper.Map<LatamQuants.PrimaryAPI.Models.InstrumentDetails, ModelViews.InstrumentDetail>(oInstrumentDetails, vInstrumentDetails);

            List<ModelViews.InstrumentDetail> colInstrumentDetails = new List<ModelViews.InstrumentDetail>();
            colInstrumentDetails.Add(vInstrumentDetails);

            vGridControl1.DataSource = colInstrumentDetails;
            vGridControl1.Update();

            this.CenterToScreen();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
