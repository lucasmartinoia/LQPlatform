namespace LQTrader
{
    partial class MarketDataHistoricUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.chkExternal = new System.Windows.Forms.CheckBox();
            this.txtEnvironment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.txtMarketID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdInfo = new DevExpress.XtraGrid.GridControl();
            this.grdvInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkExternal);
            this.pnlTop.Controls.Add(this.txtEnvironment);
            this.pnlTop.Controls.Add(this.label5);
            this.pnlTop.Controls.Add(this.dtTo);
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.dtFrom);
            this.pnlTop.Controls.Add(this.cmdSearch);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.cmdSelect);
            this.pnlTop.Controls.Add(this.txtSymbol);
            this.pnlTop.Controls.Add(this.txtMarketID);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(423, 100);
            this.pnlTop.TabIndex = 1;
            // 
            // chkExternal
            // 
            this.chkExternal.AutoSize = true;
            this.chkExternal.Location = new System.Drawing.Point(178, 69);
            this.chkExternal.Name = "chkExternal";
            this.chkExternal.Size = new System.Drawing.Size(64, 17);
            this.chkExternal.TabIndex = 13;
            this.chkExternal.Text = "External";
            this.chkExternal.UseVisualStyleBackColor = true;
            this.chkExternal.Visible = false;
            // 
            // txtEnvironment
            // 
            this.txtEnvironment.Location = new System.Drawing.Point(69, 67);
            this.txtEnvironment.Name = "txtEnvironment";
            this.txtEnvironment.Size = new System.Drawing.Size(100, 20);
            this.txtEnvironment.TabIndex = 12;
            this.txtEnvironment.Text = "REMARKETS";
            this.txtEnvironment.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Environment";
            this.label5.Visible = false;
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(221, 35);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(100, 20);
            this.dtTo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "to";
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(69, 36);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(100, 20);
            this.dtFrom.TabIndex = 8;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(270, 65);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(78, 23);
            this.cmdSearch.TabIndex = 7;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date from";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(324, 5);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(24, 23);
            this.cmdSelect.TabIndex = 4;
            this.cmdSelect.Text = "...";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(221, 7);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.ReadOnly = true;
            this.txtSymbol.Size = new System.Drawing.Size(100, 20);
            this.txtSymbol.TabIndex = 3;
            // 
            // txtMarketID
            // 
            this.txtMarketID.Location = new System.Drawing.Point(69, 7);
            this.txtMarketID.Name = "txtMarketID";
            this.txtMarketID.ReadOnly = true;
            this.txtMarketID.Size = new System.Drawing.Size(100, 20);
            this.txtMarketID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Symbol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Market ID";
            // 
            // grdInfo
            // 
            this.grdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInfo.Location = new System.Drawing.Point(0, 100);
            this.grdInfo.MainView = this.grdvInfo;
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.Size = new System.Drawing.Size(423, 295);
            this.grdInfo.TabIndex = 2;
            this.grdInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvInfo});
            // 
            // grdvInfo
            // 
            this.grdvInfo.GridControl = this.grdInfo;
            this.grdvInfo.Name = "grdvInfo";
            this.grdvInfo.OptionsBehavior.Editable = false;
            this.grdvInfo.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grdvInfo.OptionsFind.ShowSearchNavButtons = false;
            this.grdvInfo.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdvInfo.OptionsView.ColumnAutoWidth = false;
            this.grdvInfo.OptionsView.ShowGroupPanel = false;
            // 
            // MarketDataHistoricUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdInfo);
            this.Controls.Add(this.pnlTop);
            this.Name = "MarketDataHistoricUC";
            this.Size = new System.Drawing.Size(423, 395);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.TextBox txtMarketID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEnvironment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.CheckBox chkExternal;
        private DevExpress.XtraGrid.GridControl grdInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvInfo;
    }
}
