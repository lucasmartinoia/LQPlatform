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
    public partial class BlotterUC : UserControl
    {
        public BlotterUC()
        {
            InitializeComponent();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            Order frmOrder = new Order(Order.eMode.New);
            frmOrder.ShowDialog();
            if(frmOrder.OrderUpdated!=null)
            {
                // Add to Blotter
                if(gridControl1.DataSource != null)
                {
                    ((List<ModelViews.Order>)gridControl1.DataSource).Add(frmOrder.OrderUpdated);
                    gridControl1.Update();
                }
                else
                {
                    List<ModelViews.Order> oNewDS = new List<ModelViews.Order>();
                    oNewDS.Add(frmOrder.OrderUpdated);
                    gridControl1.DataSource = oNewDS;
                    gridControl1.Update();
                }
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = ModelViews.Order.UpdateOrders(null);
            gridControl1.Update();
        }
    }
}
