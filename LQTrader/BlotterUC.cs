using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

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
                    gridView1.RefreshData();
                }
                else
                {
                    List<ModelViews.Order> oNewDS = new List<ModelViews.Order>();
                    oNewDS.Add(frmOrder.OrderUpdated);
                    gridControl1.DataSource = oNewDS;
                    gridControl1.Update();
                    gridView1.RefreshData();
                }
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            List<ModelViews.Order> colBlotterOrders = null;

            if(gridControl1.DataSource!=null)
            {
                colBlotterOrders = ((List<ModelViews.Order>)gridControl1.DataSource);
            }

            gridControl1.DataSource = ModelViews.Order.UpdateOrders(colBlotterOrders);
            gridControl1.Update();
            gridView1.RefreshData();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs args = (e as DXMouseEventArgs);
            GridView view = sender as GridView;
            GridHitInfo grdHitInfo = view.CalcHitInfo(args.Location);
            Order frmOrder;

            if (grdHitInfo.InRow)
            {
                ModelViews.Order oOrder = gridView1.GetFocusedRow() as ModelViews.Order;
                frmOrder = new Order(Order.eMode.View,oOrder);
                frmOrder.ShowDialog();

                if (frmOrder.OrderUpdated != null)
                {
                    // Add to Blotter
                    if (gridControl1.DataSource != null)
                    {
                        ((List<ModelViews.Order>)gridControl1.DataSource).Remove(oOrder);
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
        }
    }
}
