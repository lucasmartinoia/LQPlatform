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
using LatamQuants.Support;

namespace LQTrader
{
    public partial class Login : Form
    {
        public bool Connected { get; set; }
        
        public Login()
        {
            InitializeComponent();

            LoadCombos();
        }

        private void LoadCombos()
        {
            // Accounts
            cboAccounts.Items.Clear();
            List<LatamQuants.Entities.Account> colAccounts=LatamQuants.Entities.Account.GetList();

            if (colAccounts.Count > 0)
            {
                foreach (LatamQuants.Entities.Account oAcc in colAccounts)
                {
                    cboAccounts.Items.Add(oAcc);
                }

                cboAccounts.ValueMember = "AccountName";
                cboAccounts.SelectedIndex = 0;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (InputValidate() == true)
                {
                    LatamQuants.Entities.Account oSelAccount = (LatamQuants.Entities.Account)cboAccounts.SelectedItem;
                    bool bResult = RestAPI.Login(oSelAccount.User, oSelAccount.Password, oSelAccount.CustodyAccount, (int)oSelAccount.AccountType);

                    if (bResult == true)
                    {
                        LoggingService.Save(EnumLogType.Information, "Login OK");
                        this.Connected = true;
                        LatamQuants.Entities.Account.CurrentAccount = oSelAccount;

                        // Load instrument details.
                        ModelViews.InstrumentDetail.colInstrumentDetails = ModelViews.InstrumentDetail.GetInstrumentsDetails();
                        // Save in database
                        ModelViews.InstrumentDetail.SaveInstruments();
                    }
                    else
                    {
                        LoggingService.Save(EnumLogType.Error, "Not logged");
                        this.Connected = false;
                    }
                }
            }
            catch(Exception ex)
            {
                string sError = "LQTrader.Login.cmdOK_Click()" + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace;
                LoggingService.Save(EnumLogType.Error, sError);

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        private bool InputValidate()
        {
            bool bReturn = false;

            if(cboAccounts.SelectedIndex<0)
            {
                MessageBox.Show("Please select an account");
            }
            else
            {
                bReturn = true;
            }

            return bReturn;
        }
    }
}
