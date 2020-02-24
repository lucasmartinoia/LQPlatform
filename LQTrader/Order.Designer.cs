namespace LQTrader
{
    partial class Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpReference = new System.Windows.Forms.GroupBox();
            this.txtPropietary = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCancelID = new System.Windows.Forms.TextBox();
            this.txtReplaceID = new System.Windows.Forms.TextBox();
            this.lblReplaceClientOrderID = new System.Windows.Forms.Label();
            this.lblCancelClOrdID = new System.Windows.Forms.Label();
            this.txtExecutionID = new System.Windows.Forms.TextBox();
            this.txtClientOrderID = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.lblExecutionID = new System.Windows.Forms.Label();
            this.lblClientOrderID = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtDisplayQuantity = new DevExpress.XtraEditors.TextEdit();
            this.lblDisplayQuantity = new System.Windows.Forms.Label();
            this.chkIceberg = new System.Windows.Forms.CheckBox();
            this.dtExpire = new System.Windows.Forms.DateTimePicker();
            this.lblExpire = new System.Windows.Forms.Label();
            this.cboTimeInForce = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSide = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarketID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtLastQuantity = new DevExpress.XtraEditors.TextEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCumulativeQuantity = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLeavesQuantity = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLastPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtAveragePrice = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTransactionTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdCancelOrder = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSend = new System.Windows.Forms.Button();
            this.grpReference.SuspendLayout();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCumulativeQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeavesQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAveragePrice.Properties)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpReference
            // 
            this.grpReference.Controls.Add(this.txtPropietary);
            this.grpReference.Controls.Add(this.label18);
            this.grpReference.Controls.Add(this.txtCancelID);
            this.grpReference.Controls.Add(this.txtReplaceID);
            this.grpReference.Controls.Add(this.lblReplaceClientOrderID);
            this.grpReference.Controls.Add(this.lblCancelClOrdID);
            this.grpReference.Controls.Add(this.txtExecutionID);
            this.grpReference.Controls.Add(this.txtClientOrderID);
            this.grpReference.Controls.Add(this.txtOrderID);
            this.grpReference.Controls.Add(this.txtAccountID);
            this.grpReference.Controls.Add(this.lblExecutionID);
            this.grpReference.Controls.Add(this.lblClientOrderID);
            this.grpReference.Controls.Add(this.lblOrderID);
            this.grpReference.Controls.Add(this.lblAccountID);
            this.grpReference.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpReference.Location = new System.Drawing.Point(0, 0);
            this.grpReference.Name = "grpReference";
            this.grpReference.Size = new System.Drawing.Size(579, 155);
            this.grpReference.TabIndex = 0;
            this.grpReference.TabStop = false;
            this.grpReference.Text = "Identification";
            // 
            // txtPropietary
            // 
            this.txtPropietary.Location = new System.Drawing.Point(385, 97);
            this.txtPropietary.Name = "txtPropietary";
            this.txtPropietary.ReadOnly = true;
            this.txtPropietary.Size = new System.Drawing.Size(100, 20);
            this.txtPropietary.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(325, 97);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Propietary";
            // 
            // txtCancelID
            // 
            this.txtCancelID.Location = new System.Drawing.Point(385, 62);
            this.txtCancelID.Name = "txtCancelID";
            this.txtCancelID.ReadOnly = true;
            this.txtCancelID.Size = new System.Drawing.Size(100, 20);
            this.txtCancelID.TabIndex = 12;
            // 
            // txtReplaceID
            // 
            this.txtReplaceID.Location = new System.Drawing.Point(385, 25);
            this.txtReplaceID.Name = "txtReplaceID";
            this.txtReplaceID.ReadOnly = true;
            this.txtReplaceID.Size = new System.Drawing.Size(100, 20);
            this.txtReplaceID.TabIndex = 11;
            // 
            // lblReplaceClientOrderID
            // 
            this.lblReplaceClientOrderID.AutoSize = true;
            this.lblReplaceClientOrderID.Location = new System.Drawing.Point(318, 28);
            this.lblReplaceClientOrderID.Name = "lblReplaceClientOrderID";
            this.lblReplaceClientOrderID.Size = new System.Drawing.Size(61, 13);
            this.lblReplaceClientOrderID.TabIndex = 10;
            this.lblReplaceClientOrderID.Text = "Replace ID";
            // 
            // lblCancelClOrdID
            // 
            this.lblCancelClOrdID.AutoSize = true;
            this.lblCancelClOrdID.Location = new System.Drawing.Point(325, 65);
            this.lblCancelClOrdID.Name = "lblCancelClOrdID";
            this.lblCancelClOrdID.Size = new System.Drawing.Size(54, 13);
            this.lblCancelClOrdID.TabIndex = 8;
            this.lblCancelClOrdID.Text = "Cancel ID";
            // 
            // txtExecutionID
            // 
            this.txtExecutionID.Location = new System.Drawing.Point(109, 123);
            this.txtExecutionID.Name = "txtExecutionID";
            this.txtExecutionID.ReadOnly = true;
            this.txtExecutionID.Size = new System.Drawing.Size(170, 20);
            this.txtExecutionID.TabIndex = 7;
            // 
            // txtClientOrderID
            // 
            this.txtClientOrderID.Location = new System.Drawing.Point(109, 90);
            this.txtClientOrderID.Name = "txtClientOrderID";
            this.txtClientOrderID.ReadOnly = true;
            this.txtClientOrderID.Size = new System.Drawing.Size(100, 20);
            this.txtClientOrderID.TabIndex = 6;
            this.txtClientOrderID.TextChanged += new System.EventHandler(this.txtClientOrderID_TextChanged);
            this.txtClientOrderID.DoubleClick += new System.EventHandler(this.txtClientOrderID_DoubleClick);
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(109, 58);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(100, 20);
            this.txtOrderID.TabIndex = 5;
            // 
            // txtAccountID
            // 
            this.txtAccountID.Location = new System.Drawing.Point(109, 28);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.ReadOnly = true;
            this.txtAccountID.Size = new System.Drawing.Size(100, 20);
            this.txtAccountID.TabIndex = 4;
            // 
            // lblExecutionID
            // 
            this.lblExecutionID.AutoSize = true;
            this.lblExecutionID.Location = new System.Drawing.Point(27, 126);
            this.lblExecutionID.Name = "lblExecutionID";
            this.lblExecutionID.Size = new System.Drawing.Size(68, 13);
            this.lblExecutionID.TabIndex = 3;
            this.lblExecutionID.Text = "Execution ID";
            // 
            // lblClientOrderID
            // 
            this.lblClientOrderID.AutoSize = true;
            this.lblClientOrderID.Location = new System.Drawing.Point(20, 93);
            this.lblClientOrderID.Name = "lblClientOrderID";
            this.lblClientOrderID.Size = new System.Drawing.Size(76, 13);
            this.lblClientOrderID.TabIndex = 2;
            this.lblClientOrderID.Text = "Client Order ID";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(49, 61);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(47, 13);
            this.lblOrderID.TabIndex = 1;
            this.lblOrderID.Text = "Order ID";
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.Location = new System.Drawing.Point(35, 31);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(61, 13);
            this.lblAccountID.TabIndex = 0;
            this.lblAccountID.Text = "Account ID";
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.txtDisplayQuantity);
            this.grpInput.Controls.Add(this.lblDisplayQuantity);
            this.grpInput.Controls.Add(this.chkIceberg);
            this.grpInput.Controls.Add(this.dtExpire);
            this.grpInput.Controls.Add(this.lblExpire);
            this.grpInput.Controls.Add(this.cboTimeInForce);
            this.grpInput.Controls.Add(this.label7);
            this.grpInput.Controls.Add(this.label6);
            this.grpInput.Controls.Add(this.txtQuantity);
            this.grpInput.Controls.Add(this.txtPrice);
            this.grpInput.Controls.Add(this.cboType);
            this.grpInput.Controls.Add(this.label5);
            this.grpInput.Controls.Add(this.cboSide);
            this.grpInput.Controls.Add(this.label4);
            this.grpInput.Controls.Add(this.label3);
            this.grpInput.Controls.Add(this.cmdSelect);
            this.grpInput.Controls.Add(this.txtSymbol);
            this.grpInput.Controls.Add(this.label2);
            this.grpInput.Controls.Add(this.txtMarketID);
            this.grpInput.Controls.Add(this.label1);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInput.Location = new System.Drawing.Point(0, 155);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(579, 239);
            this.grpInput.TabIndex = 1;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // txtDisplayQuantity
            // 
            this.txtDisplayQuantity.Location = new System.Drawing.Point(342, 189);
            this.txtDisplayQuantity.Name = "txtDisplayQuantity";
            this.txtDisplayQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDisplayQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtDisplayQuantity.TabIndex = 25;
            this.txtDisplayQuantity.Visible = false;
            // 
            // lblDisplayQuantity
            // 
            this.lblDisplayQuantity.AutoSize = true;
            this.lblDisplayQuantity.Location = new System.Drawing.Point(249, 192);
            this.lblDisplayQuantity.Name = "lblDisplayQuantity";
            this.lblDisplayQuantity.Size = new System.Drawing.Size(83, 13);
            this.lblDisplayQuantity.TabIndex = 24;
            this.lblDisplayQuantity.Text = "Display Quantity";
            this.lblDisplayQuantity.Visible = false;
            // 
            // chkIceberg
            // 
            this.chkIceberg.AutoSize = true;
            this.chkIceberg.Location = new System.Drawing.Point(109, 188);
            this.chkIceberg.Name = "chkIceberg";
            this.chkIceberg.Size = new System.Drawing.Size(62, 17);
            this.chkIceberg.TabIndex = 23;
            this.chkIceberg.Text = "Iceberg";
            this.chkIceberg.UseVisualStyleBackColor = true;
            this.chkIceberg.CheckedChanged += new System.EventHandler(this.chkIceberg_CheckedChanged);
            // 
            // dtExpire
            // 
            this.dtExpire.CustomFormat = "dd/MM/yyyy";
            this.dtExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpire.Location = new System.Drawing.Point(342, 150);
            this.dtExpire.Name = "dtExpire";
            this.dtExpire.Size = new System.Drawing.Size(121, 20);
            this.dtExpire.TabIndex = 21;
            this.dtExpire.Visible = false;
            // 
            // lblExpire
            // 
            this.lblExpire.AutoSize = true;
            this.lblExpire.Location = new System.Drawing.Point(294, 151);
            this.lblExpire.Name = "lblExpire";
            this.lblExpire.Size = new System.Drawing.Size(36, 13);
            this.lblExpire.TabIndex = 20;
            this.lblExpire.Text = "Expire";
            this.lblExpire.Visible = false;
            // 
            // cboTimeInForce
            // 
            this.cboTimeInForce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeInForce.FormattingEnabled = true;
            this.cboTimeInForce.Items.AddRange(new object[] {
            "Day",
            "IOC",
            "FOK",
            "GTD"});
            this.cboTimeInForce.Location = new System.Drawing.Point(109, 148);
            this.cboTimeInForce.Name = "cboTimeInForce";
            this.cboTimeInForce.Size = new System.Drawing.Size(121, 21);
            this.cboTimeInForce.TabIndex = 19;
            this.cboTimeInForce.SelectedIndexChanged += new System.EventHandler(this.cboTimeInForce_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Time In Force";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(342, 110);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 16;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(109, 110);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 15;
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "LIMIT",
            "MARKET"});
            this.cboType.Location = new System.Drawing.Point(342, 67);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 21);
            this.cboType.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Type";
            // 
            // cboSide
            // 
            this.cboSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSide.FormattingEnabled = true;
            this.cboSide.Items.AddRange(new object[] {
            "Buy",
            "Sell"});
            this.cboSide.Location = new System.Drawing.Point(109, 68);
            this.cboSide.Name = "cboSide";
            this.cboSide.Size = new System.Drawing.Size(121, 21);
            this.cboSide.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Side";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Price";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(485, 27);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdSelect.TabIndex = 9;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(342, 31);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.ReadOnly = true;
            this.txtSymbol.Size = new System.Drawing.Size(100, 20);
            this.txtSymbol.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Symbol";
            // 
            // txtMarketID
            // 
            this.txtMarketID.Location = new System.Drawing.Point(109, 31);
            this.txtMarketID.Name = "txtMarketID";
            this.txtMarketID.ReadOnly = true;
            this.txtMarketID.Size = new System.Drawing.Size(100, 20);
            this.txtMarketID.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Market ID";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.txtText);
            this.grpStatus.Controls.Add(this.label17);
            this.grpStatus.Controls.Add(this.txtStatus);
            this.grpStatus.Controls.Add(this.label16);
            this.grpStatus.Controls.Add(this.txtLastQuantity);
            this.grpStatus.Controls.Add(this.label15);
            this.grpStatus.Controls.Add(this.txtCumulativeQuantity);
            this.grpStatus.Controls.Add(this.label14);
            this.grpStatus.Controls.Add(this.txtLeavesQuantity);
            this.grpStatus.Controls.Add(this.label13);
            this.grpStatus.Controls.Add(this.txtLastPrice);
            this.grpStatus.Controls.Add(this.txtAveragePrice);
            this.grpStatus.Controls.Add(this.label12);
            this.grpStatus.Controls.Add(this.label11);
            this.grpStatus.Controls.Add(this.txtTransactionTime);
            this.grpStatus.Controls.Add(this.label10);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStatus.Location = new System.Drawing.Point(0, 394);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(579, 150);
            this.grpStatus.TabIndex = 2;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(342, 108);
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(170, 20);
            this.txtText.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(298, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "Text";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(109, 108);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(170, 20);
            this.txtStatus.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(55, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Status";
            // 
            // txtLastQuantity
            // 
            this.txtLastQuantity.Location = new System.Drawing.Point(481, 67);
            this.txtLastQuantity.Name = "txtLastQuantity";
            this.txtLastQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLastQuantity.Properties.ReadOnly = true;
            this.txtLastQuantity.Size = new System.Drawing.Size(79, 20);
            this.txtLastQuantity.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(448, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Last";
            // 
            // txtCumulativeQuantity
            // 
            this.txtCumulativeQuantity.Location = new System.Drawing.Point(342, 67);
            this.txtCumulativeQuantity.Name = "txtCumulativeQuantity";
            this.txtCumulativeQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCumulativeQuantity.Properties.ReadOnly = true;
            this.txtCumulativeQuantity.Size = new System.Drawing.Size(79, 20);
            this.txtCumulativeQuantity.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(294, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Filled";
            // 
            // txtLeavesQuantity
            // 
            this.txtLeavesQuantity.Location = new System.Drawing.Point(109, 67);
            this.txtLeavesQuantity.Name = "txtLeavesQuantity";
            this.txtLeavesQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLeavesQuantity.Properties.ReadOnly = true;
            this.txtLeavesQuantity.Size = new System.Drawing.Size(79, 20);
            this.txtLeavesQuantity.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Quantity Pending";
            // 
            // txtLastPrice
            // 
            this.txtLastPrice.Location = new System.Drawing.Point(481, 29);
            this.txtLastPrice.Name = "txtLastPrice";
            this.txtLastPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLastPrice.Properties.ReadOnly = true;
            this.txtLastPrice.Size = new System.Drawing.Size(79, 20);
            this.txtLastPrice.TabIndex = 17;
            // 
            // txtAveragePrice
            // 
            this.txtAveragePrice.Location = new System.Drawing.Point(342, 29);
            this.txtAveragePrice.Name = "txtAveragePrice";
            this.txtAveragePrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAveragePrice.Properties.ReadOnly = true;
            this.txtAveragePrice.Size = new System.Drawing.Size(79, 20);
            this.txtAveragePrice.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(255, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Average Price";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(448, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Last";
            // 
            // txtTransactionTime
            // 
            this.txtTransactionTime.Location = new System.Drawing.Point(109, 29);
            this.txtTransactionTime.Name = "txtTransactionTime";
            this.txtTransactionTime.ReadOnly = true;
            this.txtTransactionTime.Size = new System.Drawing.Size(140, 20);
            this.txtTransactionTime.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Transaction Time";
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.cmdModify);
            this.pnlButton.Controls.Add(this.cmdCancelOrder);
            this.pnlButton.Controls.Add(this.cmdClose);
            this.pnlButton.Controls.Add(this.cmdSend);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButton.Location = new System.Drawing.Point(0, 544);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(579, 44);
            this.pnlButton.TabIndex = 3;
            // 
            // cmdModify
            // 
            this.cmdModify.Location = new System.Drawing.Point(237, 10);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(75, 25);
            this.cmdModify.TabIndex = 3;
            this.cmdModify.Text = "MODIFY";
            this.cmdModify.UseVisualStyleBackColor = true;
            this.cmdModify.Visible = false;
            // 
            // cmdCancelOrder
            // 
            this.cmdCancelOrder.Location = new System.Drawing.Point(109, 10);
            this.cmdCancelOrder.Name = "cmdCancelOrder";
            this.cmdCancelOrder.Size = new System.Drawing.Size(108, 25);
            this.cmdCancelOrder.TabIndex = 2;
            this.cmdCancelOrder.Text = "CANCEL ORDER";
            this.cmdCancelOrder.UseVisualStyleBackColor = true;
            this.cmdCancelOrder.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(12, 10);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 25);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(492, 9);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(75, 25);
            this.cmdSend.TabIndex = 0;
            this.cmdSend.Text = "SEND";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 588);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpReference);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.grpReference.ResumeLayout(false);
            this.grpReference.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCumulativeQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeavesQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAveragePrice.Properties)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpReference;
        private System.Windows.Forms.Label lblExecutionID;
        private System.Windows.Forms.Label lblClientOrderID;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtCancelID;
        private System.Windows.Forms.TextBox txtReplaceID;
        private System.Windows.Forms.Label lblReplaceClientOrderID;
        private System.Windows.Forms.Label lblCancelClOrdID;
        private System.Windows.Forms.TextBox txtExecutionID;
        private System.Windows.Forms.TextBox txtClientOrderID;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.TextBox txtAccountID;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSide;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMarketID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTimeInForce;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private System.Windows.Forms.DateTimePicker dtExpire;
        private System.Windows.Forms.Label lblExpire;
        private DevExpress.XtraEditors.TextEdit txtDisplayQuantity;
        private System.Windows.Forms.Label lblDisplayQuantity;
        private System.Windows.Forms.CheckBox chkIceberg;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.TextBox txtTransactionTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPropietary;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.TextEdit txtLastQuantity;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.TextEdit txtCumulativeQuantity;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.TextEdit txtLeavesQuantity;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txtLastPrice;
        private DevExpress.XtraEditors.TextEdit txtAveragePrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button cmdModify;
        private System.Windows.Forms.Button cmdCancelOrder;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSend;
    }
}