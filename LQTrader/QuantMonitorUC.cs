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

namespace LQTrader
{
    public partial class QuantMonitorUC : UserControl
    {
        private List<Opportunity> _opportunities;
        private List<AcceptedOpportunity> _acceptedOpportunities;
        private List<Strategy> _strategies;
        private static DevExpress.XtraGrid.GridControl _gridOpportunities;
        private static DevExpress.XtraGrid.Views.Grid.GridView _gridvOpportunities;

        public QuantMonitorUC()
        {
            InitializeComponent();
        }

        public void Start()
        {
            _gridOpportunities = gridOpportunities;
            _gridvOpportunities = gridvOpportunities;

            // Initialize variables.
            _opportunities = new List<Opportunity>();
            _acceptedOpportunities = new List<AcceptedOpportunity>();
            _strategies = Strategy.GetList();

            // Load strategies.
            gridStrategies.DataSource = _strategies;
            gridStrategies.Update();
            gridvStrategies.RefreshData();

            // Load Opportunities
            _gridOpportunities.DataSource = _opportunities;
            _gridOpportunities.Update();
            _gridvOpportunities.RefreshData();

            // Load Accepted Opportunities
            gridAcceptedOpportunities.DataSource = _acceptedOpportunities;
            gridAcceptedOpportunities.Update();
            gridvAcceptedOpportunities.RefreshData();

            // Start receiving opportunities.
            Services.Strategist.Instance.OnOpportunityReceived += new Services.Strategist.OnOpportunityReceivedEventHandler(OnOpportunityReceived);
        }

        public void OnOpportunityReceived(Object sender, Services.Strategist.OnOpportunityReceivedArgs e)
        {
            if(e.accepted==true)
            {
                // Update Accepted Opportunities grid.
                AcceptedOpportunity oAOpportunity = (AcceptedOpportunity)e.opportunity;
                AcceptedOpportunity gAOpportunity = _acceptedOpportunities.Where(x => x.AcceptedOpportunityID == oAOpportunity.AcceptedOpportunityID).FirstOrDefault();

                if (gAOpportunity != null)
                {
                    _acceptedOpportunities.Remove(gAOpportunity);
                }

                _acceptedOpportunities.Add(oAOpportunity);

                gridAcceptedOpportunities.DataSource = _acceptedOpportunities.OrderByDescending(x=>x.AcceptedDateTime);
                gridAcceptedOpportunities.Update();
                gridvAcceptedOpportunities.RefreshData();
            }
            else
            {
                // Update Opportunities grid.
                //Opportunity oOpportunity = (Opportunity)e.opportunity;
                //Opportunity gOpportunity = _opportunities.Where(x => x.Symbol1 == oOpportunity.Symbol1 && x.Symbol2 == oOpportunity.Symbol2).FirstOrDefault();

                //if(gOpportunity!=null)
                //{
                //    _opportunities.Remove(gOpportunity);
                //}

                //_opportunities.Add(oOpportunity);

                //_gridOpportunities.DataSource = _opportunities.OrderByDescending(x=>x.DateTime);
                //_gridOpportunities.Update();
                //_gridvOpportunities.RefreshData();
            }
        }
    }
}