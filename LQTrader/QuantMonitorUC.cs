using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LatamQuants.Entities;
using DevExpress.XtraGrid.Views.Grid;

namespace LQTrader
{
    public partial class QuantMonitorUC : UserControl
    {
        private List<ModelViews.ViewOpportunity> _opportunities;
        private List<ModelViews.ViewAcceptedOpportunity> _acceptedOpportunities;

        private List<Strategy> _strategies;
        public static bool bStrategiesRefreshing = true; // Avoid cell changed events.

        private bool _refreshOpportunities = true;
        private bool _refreshAcceptedOpportunities = true;
        private Timer _timer;

        public QuantMonitorUC()
        {
            InitializeComponent();
        }

        public void Start()
        {
            // Initialize variables.
            _opportunities = ModelViews.ViewOpportunity.GetList(System.DateTime.Now.Date);
            _acceptedOpportunities = ModelViews.ViewAcceptedOpportunity.GetList(0, System.DateTime.Now.Date);
            _strategies = Strategy.GetList();

            // Load strategies.
            gridStrategies.DataSource = _strategies;
            gridStrategies.Update();
            gridvStrategies.RefreshData();

            // Load Opportunities
            LoadOpportunities();

            // Load Accepted Opportunities
            LoadAcceptedOpportunities();

            // Start receiving opportunities.
            Services.Strategist.Instance.OnOpportunityReceived += new Services.Strategist.OnOpportunityReceivedEventHandler(OnOpportunityReceived);
            bStrategiesRefreshing = false;

            ResetTimer();
        }

        private void LoadOpportunities()
        {
            _opportunities = ModelViews.ViewOpportunity.GetList(System.DateTime.Now.Date);

            if (_opportunities.Count() > 0)
            {
                gridOpportunities.DataSource = _opportunities;
                gridOpportunities.Update();
                gridvOpportunities.RefreshData();
            }
        }

        private void LoadAcceptedOpportunities()
        {
            _acceptedOpportunities = ModelViews.ViewAcceptedOpportunity.GetList(0,System.DateTime.Now.Date);

            if (_acceptedOpportunities.Count() > 0)
            {
                gridAcceptedOpportunities.DataSource = _acceptedOpportunities;
                gridAcceptedOpportunities.Update();
                gridvAcceptedOpportunities.RefreshData();
            }
        }

        private void ResetTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
            }
            else
            {
                _timer = new Timer();
                _timer.Tick += new EventHandler(tmrRefresh_Tick);
            }

            if(dunRefreshSecs.Value>0)
            {
                _timer.Interval = (Convert.ToInt32(dunRefreshSecs.Value) * 1000);
                _timer.Start();
            }
        }

        public void OnOpportunityReceived(Object sender, Services.Strategist.OnOpportunityReceivedArgs e)
        {
            //if (e.accepted == true)
            //{
            //    // Update Accepted Opportunities grid.
            //    AcceptedOpportunity oAOpportunity = (AcceptedOpportunity)e.opportunity;
            //    AcceptedOpportunity gAOpportunity = _acceptedOpportunities.Where(x => x.AcceptedOpportunityID == oAOpportunity.AcceptedOpportunityID).FirstOrDefault();

            //    if (gAOpportunity != null)
            //    {
            //        _acceptedOpportunities.Remove(gAOpportunity);
            //    }

            //    _acceptedOpportunities.Add(oAOpportunity);
            //    _refreshOpportunities = true;
            //}
            //else
            //{

            //   // Update Opportunities grid.
            //    Opportunity oOpportunity = (Opportunity)e.opportunity;
            //    Opportunity gOpportunity = _opportunities.Where(x => x.Symbol1 == oOpportunity.Symbol1 && x.Symbol2 == oOpportunity.Symbol2).FirstOrDefault();

            //    if (gOpportunity != null)
            //    {
            //        _opportunities.Remove(gOpportunity);
            //    }

            //    _opportunities.Add(oOpportunity);
            //    _refreshAcceptedOpportunities = true;
            //}
        }

        private void gridvStrategies_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(bStrategiesRefreshing==false)
            {
                // Update strategy.
                GridView view = sender as GridView;
                int dataSourceRowIndex = view.GetDataSourceRowIndex(e.RowHandle);

                if (dataSourceRowIndex > -1)
                {
                    // Update db.
                    Strategy oStrategy = _strategies[dataSourceRowIndex];
                    oStrategy.Update();

                    // Update Strategy in collection.
                    Services.Strategist.Instance.colStrategies[oStrategy.StrategyID - 1] = oStrategy;
                }
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            if (_refreshOpportunities == true)
            {
                //_refreshOpportunities = false;
                LoadOpportunities();
            }

            if (_refreshAcceptedOpportunities == true)
            {
                //_refreshAcceptedOpportunities = false;
                LoadAcceptedOpportunities();
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            ResetTimer();
            //LoadOpportunities();
            //LoadAcceptedOpportunities();
        }
    }
}
