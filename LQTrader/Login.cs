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
    public partial class Login : Form
    {
        public bool Connected { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (InputValidate() == true)
                {
                    bool bResult = RestAPI.Login(txtUser.Text, txtPassword.Text, txtAccount.Text, txtRestAPI.Text);

                    if (bResult == true)
                        this.Connected = true;
                    else
                        this.Connected = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        private bool InputValidate()
        {
            bool bReturn = false;

            if(txtUser.Text=="" || txtPassword.Text=="" || txtAccount.Text == "" || txtRestAPI.Text == "")
            {
                MessageBox.Show("Please complete all fields");
            }
            else
            {
                bReturn = true;
            }

            return bReturn;
        }
    }
}
