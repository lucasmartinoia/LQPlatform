using Entity;
using LOG;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace BymaFixTester.WinForm
{
    public partial class Form1 : Form
    {
        private readonly LogFiles log = new LogFiles();
        private QFApplication _qf;
        private static int _uniqueid = 1;
        private string UniqueID()
        {
            return Convert.ToString(_uniqueid++);
        }

        public Form1()
        {
            InitializeComponent();
        }

        #region Form-based Events

        private void Main_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Text += " v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //log.CreateLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), this.richTextBox1);
            log.CreateLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(),null);

            //Required Code to have application automatically initiate a connection. 
            try
            {
                _qf = new QFApplication();

                FillCombos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.CleanLog(3);
            log.CloseLog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _qf.Close();

        }
        #endregion

        private void UpdateCboSecurityList()
        {
            cboSecurityList.DataSource = null;
            cboSecurityList.DataSource = MessageParser.OrderMarketDataRecives;
            cboSecurityList.DisplayMember = "Description";
            cboSecurityList.ValueMember = "Id";
        }

        private void UpdateMarketData()
        {
            cboMarketData.DataSource = null;
            cboMarketData.DataSource = MessageParser.OrderMarketDataRequestRecive;
            cboMarketData.DisplayMember = "Description";
            cboMarketData.ValueMember = "Id";
        }

        private void UpdateFormDataDGV()
        {
            if (MessageParser.ListCompra.Count > 0)
            {
                dgvCompra.DataSource = null;
                dgvCompra.DataSource = MessageParser.ListCompra;
            }
            if (MessageParser.ListVenta.Count > 0)
            {
                dgvVenta.DataSource = null;
                dgvVenta.DataSource = MessageParser.ListVenta;
            }
        }


        private void Suma1AlOrdenID()
        {

            txtOrigClOrdID.Text = txtClOrdID.Text;

            Properties.Settings.Default.ClOrdID++;
            txtClOrdID.Text = "GALICIA-" + Properties.Settings.Default.ClOrdID.ToString().PadLeft(10, '0');
            Properties.Settings.Default.Save();
        }

        private void Suma1AlSecurityReqID()
        {
            Properties.Settings.Default.SecurityReqID++;
            txtSecurityReqID.Text = "GALICIA-" + Properties.Settings.Default.SecurityReqID.ToString().PadLeft(10, '0');
            Properties.Settings.Default.Save();
        }

        private void Suma1AlTradeRequestID()
        {
            Properties.Settings.Default.TradeRequestID++;
            txtTradeRequestID.Text = "GALICIA-" + Properties.Settings.Default.TradeRequestID.ToString().PadLeft(10, '0');
            Properties.Settings.Default.Save();
        }


        #region Buttons
        private void BtnNewOrderSingle_Click(object sender, EventArgs e)
        {

            if (cboSecurityType.SelectedValue != null)
            {
                switch (cboSide.SelectedValue)
                {
                    case "1":
                        MessageParser.AddCompra(txtClOrdID.Text, Convert.ToInt32(txtPrice.Text), Convert.ToDecimal(txtQuantity.Text), "Send market");
                        break;
                    case "2":
                    case "5":
                        MessageParser.AddVenta(txtClOrdID.Text, Convert.ToInt32(txtPrice.Text), Convert.ToDecimal(txtQuantity.Text), "Send market");
                        break;
                    default:

                        break;
                }



                _qf.NewOrderSingle50SP2(new NewOrderSingleSend()
                {
                    ClOrdID_11 = txtClOrdID.Text,
                    Side_54 = Convert.ToChar(cboSide.SelectedValue),
                    OrderType_40 = Convert.ToChar(cboOrdType.SelectedValue),
                    Quantity_53 = Convert.ToDecimal(txtQuantity.Text),
                    TimeInForce_59 = Convert.ToChar(cboTimeInForce.SelectedValue),
                    Currency_15 = txtCurrency.Text,
                    Account_1 = txtAccount.Text,
                    Price_44 = Convert.ToInt32(txtPrice.Text),
                    Symbol_55 = txtSymbol.Text,
                    SettlType_63 = cboSettlmntTyp.SelectedValue.ToString(),
                    SecurityType_167 = cboSecurityType.SelectedValue.ToString(),
                    SecurityExchange_207 = txtSecurityExchange.Text,
                    ExpireDate_432 = txtExpireDate.Enabled == true ? txtExpireDate.Text : null,
                    CFICode_461 = txtCFICode.Text,
                    OrderCapacity_528 = Convert.ToChar(cboOrderCapacity.SelectedValue),
                    PartyID_448 = txtPartyID.Text,
                    PartyIDSource_447 = Convert.ToChar(cboPartyIDSource.SelectedValue),
                    PartyRole_452 = Convert.ToInt32(cboPartyRole.SelectedValue),
                    TradeFrag_29501 = Convert.ToChar(cboTradeFrag.SelectedValue)
                });

                Suma1AlOrdenID();
            }
            else
            {
                log.WriteLog("SecurityType no especificado", Color.Red);
            }
        }

        private void BtnMarketDataRequest_Click(object sender, EventArgs e)
        {

            _qf.QueryMarketDataRequest(new MarketDataRequestSend()
            {
                Currency_15 = txtCurrency.Text,
                SecurityType_167 = cboSecurityType.SelectedValue.ToString(),
                SecurityExchange_207 = txtSecurityExchange.Text,
                SettlType_63 = cboSettlmntTyp.SelectedValue.ToString(),
                SubscriptionRequestType_263 = Convert.ToChar(cboSubscriptionRequestType.SelectedValue),
                Symbol_55 = txtSymbol.Text
            });
        }

        private void BtnSecurityDefinition_Click(object sender, EventArgs e)
        {
            _qf.QuerySecurityDefinition(new SecurityDefinitionSend()
            {
                Symbol_55 = txtSymbol.Text,
                SecurityID_48 = txtSecurityID.Text,
                SecurityType_167 = cboSecurityType.SelectedValue.ToString(),
                SecurityExchange_207 = txtSecurityExchange.Text,
                SecurityReqID_320 = txtSecurityReqID.Text
            });

            Suma1AlSecurityReqID();
        }

        private void BtnOrderStatusRequest_Click(object sender, EventArgs e)
        {
            _qf.QueryOrderStatusRequest(new OrderStatusRequestSend()
            {
                ClOrdID_11 = txtClOrdID.Text,
                Side_54 = Convert.ToChar(cboSide.SelectedValue),
                PartyID_448 = txtPartyID.Text,
                PartyIDSource_447 = Convert.ToChar(cboPartyIDSource.SelectedValue),
                PartyRole_452 = Convert.ToInt32(cboPartyRole.SelectedValue)
            });
        }

        private void BtnOrderCancelRequest_Click(object sender, EventArgs e)
        {
            _qf.QueryCancelOrder(new OrderCancelSend()
            {
                ClOrdID_11 = txtClOrdID.Text,
                Side_54 = Convert.ToChar(cboSide.SelectedValue),
                Symbol_55 = txtSymbol.Text,
                SecurityType_167 = cboSecurityType.SelectedValue.ToString(),
                Currency_15 = txtCurrency.Text,
                SettlmntTyp_63 = cboSettlmntTyp.SelectedValue.ToString(),
                PartyID_448 = txtPartyID.Text,
                PartyIDSource_447 = Convert.ToChar(cboPartyIDSource.SelectedValue),
                PartyRole_452 = Convert.ToInt32(cboPartyRole.SelectedValue),
                OrigClOrdID_41 = txtOrigClOrdID.Text,
            });

            Suma1AlOrdenID();
        }

        private void BtnOrderCancelReplace_Click(object sender, EventArgs e)
        {
            //char bs;
            //if (cbxBS.Text == "BUY")
            //{ bs = QuickFix.Fields.Side.BUY; }
            //else
            //{ bs = QuickFix.Fields.Side.SELL; }

            //TT.SendMsg send = new TT.SendMsg();
            //send.ttOrderCancelReplace(new string[] { _gw, _product, QuickFix.Fields.SecurityType.FUTURE, cbxContracts.Text },
            //    _account, _qf.getLastSiteOrderkey(),_tradePrice, (double)new System.Random().Next(1,10), bs,
            //    QuickFix.Fields.OrdType.LIMIT);
        }

        private void BtnSecurityListRequest_Click(object sender, EventArgs e)
        {
            _qf.QuerySecurityListRequest(UniqueID());
        }

        private void BtnIniciate_Click(object sender, EventArgs e)
        {

            if (!File.Exists(txtRutaConfigMD.Text))
            {
                richTextBox1.AppendText("No existe el archivo de configuracion MD");
            }
            else
            if (_qf != null)
            {
                _qf.RegisterFormController(log.WriteLog);
                _qf.RegisterCboSecurityListData(UpdateCboSecurityList);
                _qf.RegisterCboMarketData(UpdateMarketData);
                _qf.RegisterDGV(UpdateFormDataDGV);

                _qf.Initiate(txtRutaConfigMD.Text, txtUsuarioMD.Text, txtPasswordMD.Text, true, this);
            }
        }

        private void BtnOff_Click(object sender, EventArgs e)
        {
            if (_qf != null)
            {
                _qf.Close();
                _qf = new QFApplication();
            }
        }

        private void BtnTradeCaptureReportRequest_Click(object sender, EventArgs e)
        {
            _qf.QueryTradeCaptureReportRequest(txtTradeRequestID.Text,
                txtPartyID.Text,
                    Convert.ToChar(cboPartyIDSource.SelectedValue),
                    Convert.ToInt32(cboPartyRole.SelectedValue));

            Suma1AlTradeRequestID();
        }
        #endregion

        #region TextBox
        private void TxtNumeroTag_TextChanged(object sender, EventArgs e)
        {
            txtNumeroEnum.Text = "";
            lblNumeroEnum.Text = "";
            if (int.TryParse(txtNumeroTag.Text, out int intValue) && intValue <= 1621 && intValue > 0)
            {
                string name = QFHelper.GetTagNameByValue(intValue);
                lblNumeroTagResponse.Text = name;

                bool tieneEnumerado = QFHelper.HasEnumValues(name);
                txtNumeroEnum.Visible = tieneEnumerado;
                lblTagEnum.Visible = tieneEnumerado;
            }
            else
            {
                txtNumeroEnum.Visible = false;
                lblTagEnum.Visible = false;
                lblNumeroTagResponse.Text = "";
            }
        }

        private void TxtMsgType_TextChanged(object sender, EventArgs e)
        {
            lblMsgTypeResponse.Text = QFHelper.GetMsgTypeByValue(txtMsgType.Text);
        }

        private void TxtNumeroEnum_TextChanged(object sender, EventArgs e)
        {
            lblNumeroEnum.Text = _qf.GetNameByTagEnumValue(lblNumeroTagResponse.Text, txtNumeroEnum.Text);
        }
        #endregion

        #region Combos
        private void FillCombos()
        {
            GetRandomExpireDate();

            txtOrigClOrdID.Text = "GALICIA-" + (Properties.Settings.Default.ClOrdID - 1).ToString().PadLeft(10, '0');
            txtClOrdID.Text = "GALICIA-" + Properties.Settings.Default.ClOrdID.ToString().PadLeft(10, '0');

            txtSecurityReqID.Text = "GALICIA-" + Properties.Settings.Default.SecurityReqID.ToString().PadLeft(10, '0');

            cboOrdType.DataSource = _qf.GetOrdTypeArrayForCombo();
            cboOrdType.DisplayMember = "Value";
            cboOrdType.ValueMember = "Key";
            cboOrdType.SelectedValue = "2";

            FillFilteredCboSide(new string[] { "1", "2", "5" });

            cboTimeInForce.DataSource = _qf.GetTimeInForceArrayForCombo();
            cboTimeInForce.DisplayMember = "Value";
            cboTimeInForce.ValueMember = "Key";
            cboTimeInForce.SelectedValue = "6";

            cboSettlmntTyp.DataSource = _qf.GetSettlmntTypeArrayForCombo();
            cboSettlmntTyp.DisplayMember = "Value";
            cboSettlmntTyp.ValueMember = "Key";
            cboSettlmntTyp.SelectedValue = "3";

            cboSecurityType.DataSource = _qf.GetSecurityTypeArrayForCombo();
            cboSecurityType.DisplayMember = "Value";
            cboSecurityType.ValueMember = "Key";
            cboSecurityType.SelectedValue = "GO";

            cboOrderCapacity.DataSource = _qf.GetOrderCapacityArrayForCombo();
            cboOrderCapacity.DisplayMember = "Value";
            cboOrderCapacity.ValueMember = "Key";
            cboOrderCapacity.SelectedValue = "A";

            cboTradeFrag.DataSource = _qf.GetTradeFragArrayForCombo();
            cboTradeFrag.DisplayMember = "Value";
            cboTradeFrag.ValueMember = "Key";
            cboTradeFrag.SelectedValue = "1";

            cboPartyIDSource.DataSource = _qf.GetPartyIDSourceArrayForCombo();
            cboPartyIDSource.DisplayMember = "Value";
            cboPartyIDSource.ValueMember = "Key";
            cboPartyIDSource.SelectedValue = "D";

            cboPartyRole.DataSource = _qf.GetPartyRoleArrayForCombo();
            cboPartyRole.DisplayMember = "Value";
            cboPartyRole.ValueMember = "Key";
            cboPartyRole.SelectedValue = "53";

            cboSubscriptionRequestType.DataSource = _qf.GetSubscriptionRequestTypeForCombo();
            cboSubscriptionRequestType.DisplayMember = "Value";
            cboSubscriptionRequestType.ValueMember = "Key";
            cboSubscriptionRequestType.SelectedValue = "0";
        }

        #region SelectedIndexChanged

        private void CboTimeInForce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimeInForce.SelectedValue.ToString() != "6")
            {
                txtExpireDate.Enabled = false;
                txtExpireDate.Text = "";
            }
            else
            {
                GetRandomExpireDate();
            }
        }

        private void CboSecurityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderMarketDataRecive orderMarketDataRecive = ((OrderMarketDataRecive)cboSecurityList.SelectedItem);
            txtCurrency.Text = orderMarketDataRecive.Currency_15;
            txtSymbol.Text = orderMarketDataRecive.Symbol_55;
            txtSecurityID.Text = orderMarketDataRecive.SecurityID_48;
            FillFilteredCboTimeInForce(orderMarketDataRecive.TimeInForce_59);
            FillFilteredCboOrdType(orderMarketDataRecive.OrdType_40);
            FillFilteredCboSecurityType(orderMarketDataRecive.SecurityType_167);
            txtSecurityExchange.Text = orderMarketDataRecive.SecurityExchange_207;
            txtCFICode.Text = orderMarketDataRecive.CFICode_461;
        }

        private void CboOrdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboOrdType.SelectedValue.ToString())
            {
                case "3":
                case "4":
                    txtStopPx.Enabled = true;
                    break;
                default:
                    txtStopPx.Enabled = false;
                    txtStopPx.Text = "";
                    break;
            }

        }
        #endregion

        #region Combos Filtered
        private void FillFilteredCboSecurityType(string securityType_167)
        {
            cboSecurityType.DataSource = _qf.GetSecurityTypeArrayForCombo().Where(item => securityType_167 == item.Key).ToList();
            cboSecurityType.DisplayMember = "Value";
            cboSecurityType.ValueMember = "Key";
        }

        private void FillFilteredCboSide(string[] side_54)
        {

            cboSide.DataSource = _qf.GetSideArrayForCombo().Where(item => side_54.Contains(item.Key)).ToList();
            cboSide.DisplayMember = "Value";
            cboSide.ValueMember = "Key";
        }

        private void FillFilteredCboOrdType(char[] ordType_40)
        {
            cboOrdType.DataSource = _qf.GetOrdTypeArrayForCombo().Where(item => ordType_40.Contains(Convert.ToChar(item.Key))).ToList();
            cboOrdType.DisplayMember = "Value";
            cboOrdType.ValueMember = "Key";
        }

        private void FillFilteredCboTimeInForce(char[] timeInForce_59)
        {
            cboTimeInForce.DataSource = _qf.GetTimeInForceArrayForCombo().Where(item => timeInForce_59.Contains(Convert.ToChar(item.Key))).ToList();
            cboTimeInForce.DisplayMember = "Value";
            cboTimeInForce.ValueMember = "Key";
        }
        #endregion

        #endregion

        private void GetRandomExpireDate()
        {
            Random random = new Random();
            int dias = random.Next(1, 5);

            txtExpireDate.Text = DateTime.Now.AddDays(dias).ToString("yyyyMMdd");
            txtExpireDate.Enabled = true;
        }

        private void BtnNewOrderSingleINOM_Click(object sender, EventArgs e)
        {
            OrderBondEquityInput orderBondEquity = new OrderBondEquityInput
            {
                Amount = 0,

                BrokerID = "BGBA",
                ChannelID = "BT",
                OperatorID = "L0673781",
                ClientID = txtAccount.Text,
                OrderDateTime = DateTime.Now,
                Action = "N",
                Confirmed = true,
                ProductType = "Equity",
                Comments = "",
                RecycleActive = true,
                RecycleFrequence = 0,
                RecycleLimitTime = "",
                ExchangeRate = 0,
                OperationsStockTicket = "",
                Currency = txtCurrency.Text,
                Price = Convert.ToDouble(txtPrice.Text),
                Shares = Convert.ToDecimal(txtQuantity.Text),
                CustodyAccountNo = "1",
                ExternalReference = 0,
                Scheduled = true,
                ExecutionDate = DateTime.Now,
                AuthorizerID = "",
                OfficialLetter = true,
                OfficialLetterNo = 0,
                SettleDate = DateTime.Now,
                SettleTerm = (Convert.ToInt32(((System.Collections.Generic.KeyValuePair<string, string>)cboSettlmntTyp.SelectedItem).Key) - 1) * 24,
                MarketName = "BYMA",
                InstrumentID = txtSymbol.Text,
                OrderType = ((System.Collections.Generic.KeyValuePair<string, string>)cboOrdType.SelectedItem).Key == "1" ? "LIMIT" : "MARKET",
                ProductCodeType = "",
                ExpireDate = DateTime.Now,
                ExpireTime = DateTime.Now.ToString("HH:MM"),
                Buy = ((System.Collections.Generic.KeyValuePair<string, string>)cboSide.SelectedItem).Key == "1" ? true : false,
                StopLoss = 0,
                TakeProfit = 0,
                OrderLife = Convert.ToInt32(((System.Collections.Generic.KeyValuePair<string, string>)cboTimeInForce.SelectedItem).Key),
                PositionOperation = true,
                ExcludedMarkets = ""
            };

            //((System.Collections.Generic.KeyValuePair<string, string>)cboSide.SelectedItem).Key

            //controller = "BondEquity";
            //string INOMCore = ReadConfig(ReadSettings.INOMCore) + controller;

            //orderBondEquity = await CommWebApi.SendAsync<OrderBondEquityInput, OrderBondEquityInput>(INOMCore, orderBondEquity);
        }
    }
}
