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
        public List<ModelViews.Order> OrderUpdated { get; private set; }

        public Order(eMode pMode, ModelViews.Order pOrder = null)
        {
            InitializeComponent();

            this.OrderUpdated = new List<ModelViews.Order>();
            m_Mode = pMode;

            if(m_Mode==eMode.View || m_Mode==eMode.Edit)
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
            txtOriginalOrderID.Text = pOrder.OriginalClientOrderID;
            txtPropietary.Text = pOrder.Proprietary;

            //--------------- Input section
            txtMarketID.Text = pOrder.MarketID;
            txtSymbol.Text = pOrder.Symbol;
            cmdSelect.Visible = false;

            if (pOrder.Side.ToLower() == "buy")
            {
                cboSide.SelectedIndex = 0;
            }
            else
            {
                cboSide.SelectedIndex = 1;
            }

            if (pOrder.Type.ToLower() == "limit")
                cboType.SelectedIndex = 0;
            else
                cboType.SelectedIndex = 1;

            txtPrice.EditValue = pOrder.Price;
            txtQuantity.EditValue = pOrder.Quantity;

            if (pOrder.TimeInForce.ToLower() == "day")
                cboTimeInForce.SelectedIndex = 0;
            else
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

            // Not allow input
            cboSide.Enabled = false;
            cboTimeInForce.Enabled = false;
            txtPrice.ReadOnly = true;
            txtQuantity.ReadOnly = true;
            chkIceberg.Enabled = false;
            cboType.Enabled = false;
            txtDisplayQuantity.ReadOnly = true;

            //--------------- Buttons

            if (String.IsNullOrEmpty(txtOrderID.Text) == false && txtOrderID.Text!="NONE")
                cmdUpdateByOrderID.Visible = true;
            else
                cmdUpdateByOrderID.Visible = false;

            if (String.IsNullOrEmpty(txtClientOrderID.Text) == false)
                cmdUpdateByClientOrderID.Visible = true;
            else
                cmdUpdateByClientOrderID.Visible = false;

            if (String.IsNullOrEmpty(txtExecutionID.Text) == false)
                cmdUpdateByExecutionID.Visible = true;
            else
                cmdUpdateByExecutionID.Visible = false;


            if((txtStatus.Text=="PENDING" || txtStatus.Text=="SENT") && this.m_Mode== eMode.Edit)
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
            ModelViews.Order oOrder = null;
            bool bResult = false;

            try
            {
                // NEW
                if (this.m_Mode == eMode.New)
                {
                    oOrder = PopulateOrderFromScreen();
                    bResult = oOrder.Send();

                    if (bResult == true)
                    {
                        this.OrderUpdated.Add(oOrder);
                        MessageBox.Show("Order sent successfully to the market", "Send Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                // REPLACEMENT
                else
                {
                    oOrder = this.m_OrderOriginal.Clone();

                    if (txtClientOrderID.ReadOnly == false)
                        oOrder.ClientOrderID = txtClientOrderID.Text;

                    ModelViews.Order oNewOrder = oOrder.Replace(Convert.ToDouble(txtPrice.EditValue), Convert.ToDouble(txtQuantity.EditValue));
                    //this.OrderUpdated.Add(oOrder);
                    //this.OrderUpdated.Add(oNewOrder);
                    MessageBox.Show("Order replacement sent successfully to the market", "Replace Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                oReturn.OriginalClientOrderID = txtOriginalOrderID.Text;
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
                    oReturn.DisplayQuantity=Convert.ToDouble(txtDisplayQuantity.EditValue);
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

        private void txtClientOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClientOrderID_DoubleClick(object sender, EventArgs e)
        {
            txtClientOrderID.ReadOnly = false;
        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            txtPrice.ReadOnly = false;
            txtQuantity.ReadOnly = false;
            cmdSend.Visible = true;
        }

        private void cmdCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult oResult = MessageBox.Show("Do you confirm current order CANCELATION?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (oResult == DialogResult.Yes)
                {
                    ModelViews.Order oOrder = this.m_OrderOriginal.Clone();

                    if (txtClientOrderID.ReadOnly == false)
                        oOrder.ClientOrderID = txtClientOrderID.Text;

                    bool bResult = oOrder.Cancel();

                    if (bResult)
                    {
                        this.OrderUpdated.Add(oOrder);
                        MessageBox.Show("Cancelation was sent to market", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grpReference_Enter(object sender, EventArgs e)
        {

        }

        private void cmdUpdateByOrderID_Click(object sender, EventArgs e)
        {
            try
            {
                ModelViews.Order oOrder = this.m_OrderOriginal.Clone();
                oOrder.Update(txtOrderID.Text, null, null);
                this.OrderUpdated.Add(oOrder);
                PopulateScreen(oOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdUpdateByClientOrderID_Click(object sender, EventArgs e)
        {
            try
            {
                ModelViews.Order oOrder = this.m_OrderOriginal.Clone();
                oOrder.Update(null, txtClientOrderID.Text,null);
                this.OrderUpdated.Add(oOrder);
                PopulateScreen(oOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdUpdateByExecutionID_Click(object sender, EventArgs e)
        {
            try
            {
                ModelViews.Order oOrder = this.m_OrderOriginal.Clone();
                oOrder.Update(null, null, txtExecutionID.Text);
                this.OrderUpdated.Add(oOrder);
                PopulateScreen(oOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
