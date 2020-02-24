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
    public partial class Order : Form
    {
        public enum eMode
        {
            NotSet=0,
            New=1,
            View=2,
            Edit=3,
        }

        private eMode m_Mode = eMode.NotSet;
        private ModelViews.Order m_OrderOriginal=null;

        // mOrder is not null when is necessary update the list of orders due an action of New, Replace or Delete.
        public ModelViews.Order OrderUpdated { get; private set; }

        public Order(eMode pMode, ModelViews.Order pOrder = null)
        {
            InitializeComponent();

            m_Mode = pMode;

            if(m_Mode==eMode.View)
            {
                m_OrderOriginal = pOrder;
                PopulateScreen(m_OrderOriginal);
            }
            else
            {
                cmdCancelOrder.Visible = false;
                cmdModify.Visible = false;
                txtAccountID.Text = LatamQuants.PrimaryAPI.RestAPI.m_account;
            }
        }

        private void PopulateScreen(ModelViews.Order pOrder)
        {
            //--------------- Identification section
            txtAccountID.Text = pOrder.AccountID;
            txtOrderID.Text = pOrder.OrderID;
            txtClientOrderID.Text = pOrder.ClientOrderID;
            txtExecutionID.Text = pOrder.ExecutionID;
            txtReplaceID.Text = pOrder.ReplaceClientOrderID;
            txtCancelID.Text = pOrder.CancelClientOrderID;
            txtPropietary.Text = pOrder.Proprietary;

            //--------------- Input section
            txtMarketID.Text = pOrder.MarketID;
            txtSymbol.Text = pOrder.Symbol;
            cmdSelect.Visible = false;
            
            //if(pOrder.Side=="Buy")
            //{
            //    cboSide.SelectedIndex = 0;
            //}
            //else
            //{
            //    cboSide.SelectedIndex = 1;
            //}
            cboSide.SelectedItem = pOrder.Side;

            //if(pOrder.Type=="LIMIT")
            //{
            //    cboType.SelectedIndex = 0;
            //}
            //else
            //{
            //    cboType.SelectedIndex = 1;
            //}
            cboType.SelectedItem = pOrder.Type;

            txtPrice.EditValue = pOrder.Price;
            txtQuantity.EditValue = pOrder.Quantity;
            cboTimeInForce.SelectedItem=pOrder.TimeInForce;

            if(pOrder.TimeInForce=="GTD")
            {
                lblExpire.Visible = true;
                dtExpire.Visible = true;
                dtExpire.Value = (DateTime)pOrder.ExpireDate;
            }
            else
            {
                lblExpire.Visible = false;
                dtExpire.Visible = false;
            }

            chkIceberg.Checked = pOrder.Iceberg;

            if(pOrder.Iceberg==true)
            {
                lblDisplayQuantity.Visible = true;
                txtDisplayQuantity.Visible = true;
                txtDisplayQuantity.EditValue = pOrder.DisplayQuantity;
            }
            else
            {
                lblDisplayQuantity.Visible = false;
                txtDisplayQuantity.Visible = false;
            }

            //--------------- Status section
            txtTransactionTime.Text = pOrder.TransactionTime;
            txtAveragePrice.EditValue = pOrder.AveragePrice;
            txtLastPrice.EditValue = pOrder.LastPrice;
            txtLeavesQuantity.EditValue = pOrder.LeavesQuantity;
            txtCumulativeQuantity.EditValue = pOrder.CumulativeQuantity;
            txtLastQuantity.EditValue = pOrder.LastQuantity;
            txtStatus.Text = pOrder.Status;
            txtText.Text = pOrder.Text;

            //--------------- Buttons
            if(txtStatus.Text=="PENDING")
            {
                cmdCancelOrder.Visible = true;
                cmdModify.Visible = true;
            }
            else
            {
                cmdCancelOrder.Visible = false;
                cmdModify.Visible = false;
            }

            cmdSend.Visible = false;
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            ModelViews.Order oOrder = PopulateOrderFromScreen();

            try
            {
                bool bResult = oOrder.Send(this.m_OrderOriginal);

                if (bResult == true)
                {
                    // Update Client Order ID
                    txtClientOrderID.Text = oOrder.ClientOrderID;
                    txtStatus.Text = "SENT";
                    MessageBox.Show("order sent successfully to the market" , "INFO", MessageBoxButtons.OK);
                    this.OrderUpdated = PopulateOrderFromScreen();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        private ModelViews.Order PopulateOrderFromScreen()
        {
            ModelViews.Order oReturn = new ModelViews.Order();

            if(this.m_Mode== eMode.New)
            {
                //--------------- Identification section
                oReturn.AccountID=txtAccountID.Text;
                oReturn.OrderID=txtOrderID.Text;
                oReturn.ClientOrderID=txtClientOrderID.Text;
                oReturn.ExecutionID=txtExecutionID.Text;
                oReturn.ReplaceClientOrderID=txtReplaceID.Text;
                oReturn.CancelClientOrderID=txtCancelID.Text;
                oReturn.Proprietary=txtPropietary.Text;

                //--------------- Input section
                oReturn.MarketID=txtMarketID.Text;
                oReturn.Symbol=txtSymbol.Text;
                oReturn.Side=(string)cboSide.SelectedItem;
                oReturn.Type=(string)cboType.SelectedItem;
                oReturn.Price=txtPrice.EditValue==null?0:Convert.ToDouble(txtPrice.EditValue);
                oReturn.Quantity= txtQuantity.EditValue == null ? 0 : Convert.ToDouble(txtQuantity.EditValue);
                oReturn.TimeInForce=(string)cboTimeInForce.SelectedItem;

                if ((string)cboTimeInForce.SelectedItem == "GTD")
                {
                    oReturn.ExpireDate = dtExpire.Value;
                }

                oReturn.Iceberg=chkIceberg.Checked;

                if (oReturn.Iceberg == true)
                {
                    oReturn.DisplayQuantity=(double)txtDisplayQuantity.EditValue;
                }

                //--------------- Status section
                oReturn.TransactionTime=txtTransactionTime.Text;
                oReturn.AveragePrice= txtAveragePrice.EditValue == null ? 0 : Convert.ToDouble(txtAveragePrice.EditValue);
                oReturn.LastPrice= txtLastPrice.EditValue == null ? 0 : Convert.ToDouble(txtLastPrice.EditValue);
                oReturn.LeavesQuantity= txtLeavesQuantity.EditValue == null ? 0 : Convert.ToDouble(txtLeavesQuantity.EditValue);
                oReturn.CumulativeQuantity= txtCumulativeQuantity.EditValue == null ? 0 : Convert.ToDouble(txtCumulativeQuantity.EditValue);
                oReturn.LastQuantity= txtLastQuantity.EditValue == null ? 0 : Convert.ToDouble(txtLastQuantity.EditValue);
                oReturn.Status=txtStatus.Text;
                oReturn.Text=txtText.Text;
            }

            return oReturn;
        }

        private void cboTimeInForce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTimeInForce.SelectedItem.ToString()=="GTD")
            {
                lblExpire.Visible = true;
                dtExpire.Visible = true;
            }
            else
            {
                lblExpire.Visible = false;
                dtExpire.Visible = false;
            }
        }

        private void chkIceberg_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIceberg.Checked==true)
            {
                txtDisplayQuantity.Visible = true;
                lblDisplayQuantity.Visible = true;
            }
            else
            {
                txtDisplayQuantity.Visible = false;
                lblDisplayQuantity.Visible = false;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            InstrumentSelect frmInstrumentSelect = new InstrumentSelect();
            frmInstrumentSelect.ShowDialog();
            
            if(frmInstrumentSelect.SelectedInstrument!=null)
            {
                txtMarketID.Text = frmInstrumentSelect.SelectedInstrument.MarketID;
                txtSymbol.Text = frmInstrumentSelect.SelectedInstrument.Symbol;
            }
        }

        private void txtClientOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClientOrderID_DoubleClick(object sender, EventArgs e)
        {
            txtClientOrderID.ReadOnly = false;
        }
    }
}
