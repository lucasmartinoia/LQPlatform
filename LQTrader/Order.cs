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
        private ModelViews.Order m_OrderOriginal;

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

            
        }

        private ModelViews.Order PopulateOrderFromScreen()
        {
            ModelViews.Order oReturn = null;



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
    }
}
