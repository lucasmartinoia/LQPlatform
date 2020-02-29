namespace LQTrader
{
    partial class MarketDataUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarketID = new System.Windows.Forms.TextBox();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDepth = new System.Windows.Forms.NumericUpDown();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.pnlMD = new System.Windows.Forms.Panel();
            this.grdInfo = new DevExpress.XtraGrid.GridControl();
            this.grdvInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlDepth = new System.Windows.Forms.Panel();
            this.pnlBids = new System.Windows.Forms.Panel();
            this.pnlOffers = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.grdBids = new DevExpress.XtraGrid.GridControl();
            this.grdvBids = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label5 = new System.Windows.Forms.Label();
            this.grdOffers = new DevExpress.XtraGrid.GridControl();
            this.grdvOffers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepth)).BeginInit();
            this.pnlMD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvInfo)).BeginInit();
            this.pnlDepth.SuspendLayout();
            this.pnlBids.SuspendLayout();
            this.pnlOffers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOffers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOffers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cmdSearch);
            this.pnlTop.Controls.Add(this.txtDepth);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.cmdSelect);
            this.pnlTop.Controls.Add(this.txtSymbol);
            this.pnlTop.Controls.Add(this.txtMarketID);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(350, 61);
            this.pnlTop.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Symbol";
            // 
            // txtMarketID
            // 
            this.txtMarketID.Location = new System.Drawing.Point(63, 7);
            this.txtMarketID.Name = "txtMarketID";
            this.txtMarketID.ReadOnly = true;
            this.txtMarketID.Size = new System.Drawing.Size(100, 20);
            this.txtMarketID.TabIndex = 2;
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(221, 7);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.ReadOnly = true;
            this.txtSymbol.Size = new System.Drawing.Size(100, 20);
            this.txtSymbol.TabIndex = 3;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Depth";
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(63, 34);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(48, 20);
            this.txtDepth.TabIndex = 6;
            this.txtDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDepth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(228, 33);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(78, 23);
            this.cmdSearch.TabIndex = 7;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // pnlMD
            // 
            this.pnlMD.Controls.Add(this.grdInfo);
            this.pnlMD.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMD.Location = new System.Drawing.Point(0, 61);
            this.pnlMD.Name = "pnlMD";
            this.pnlMD.Size = new System.Drawing.Size(350, 209);
            this.pnlMD.TabIndex = 1;
            // 
            // grdInfo
            // 
            this.grdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInfo.Location = new System.Drawing.Point(0, 0);
            this.grdInfo.MainView = this.grdvInfo;
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.Size = new System.Drawing.Size(350, 209);
            this.grdInfo.TabIndex = 0;
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
            // pnlDepth
            // 
            this.pnlDepth.Controls.Add(this.pnlOffers);
            this.pnlDepth.Controls.Add(this.pnlBids);
            this.pnlDepth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDepth.Location = new System.Drawing.Point(0, 270);
            this.pnlDepth.Name = "pnlDepth";
            this.pnlDepth.Size = new System.Drawing.Size(350, 208);
            this.pnlDepth.TabIndex = 2;
            // 
            // pnlBids
            // 
            this.pnlBids.Controls.Add(this.grdBids);
            this.pnlBids.Controls.Add(this.label4);
            this.pnlBids.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBids.Location = new System.Drawing.Point(0, 0);
            this.pnlBids.Name = "pnlBids";
            this.pnlBids.Size = new System.Drawing.Size(175, 208);
            this.pnlBids.TabIndex = 0;
            // 
            // pnlOffers
            // 
            this.pnlOffers.Controls.Add(this.grdOffers);
            this.pnlOffers.Controls.Add(this.label5);
            this.pnlOffers.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOffers.Location = new System.Drawing.Point(175, 0);
            this.pnlOffers.Name = "pnlOffers";
            this.pnlOffers.Size = new System.Drawing.Size(175, 208);
            this.pnlOffers.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bids";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdBids
            // 
            this.grdBids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBids.Location = new System.Drawing.Point(0, 13);
            this.grdBids.MainView = this.grdvBids;
            this.grdBids.Name = "grdBids";
            this.grdBids.Size = new System.Drawing.Size(175, 195);
            this.grdBids.TabIndex = 1;
            this.grdBids.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvBids});
            // 
            // grdvBids
            // 
            this.grdvBids.GridControl = this.grdBids;
            this.grdvBids.Name = "grdvBids";
            this.grdvBids.OptionsBehavior.Editable = false;
            this.grdvBids.OptionsFilter.AllowColumnMRUFilterList = false;
            this.grdvBids.OptionsFind.ShowSearchNavButtons = false;
            this.grdvBids.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdvBids.OptionsView.ColumnAutoWidth = false;
            this.grdvBids.OptionsView.ShowGroupPanel = false;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Offers";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdOffers
            // 
            this.grdOffers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOffers.Location = new System.Drawing.Point(0, 13);
            this.grdOffers.MainView = this.grdvOffers;
            this.grdOffers.Name = "grdOffers";
            this.grdOffers.Size = new System.Drawing.Size(175, 195);
            this.grdOffers.TabIndex = 1;
            this.grdOffers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOffers});
            // 
            // grdvOffers
            // 
            this.grdvOffers.GridControl = this.grdOffers;
            this.grdvOffers.Name = "grdvOffers";
            this.grdvOffers.OptionsBehavior.Editable = false;
            this.grdvOffers.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grdvOffers.OptionsFind.ShowSearchNavButtons = false;
            this.grdvOffers.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdvOffers.OptionsView.ColumnAutoWidth = false;
            this.grdvOffers.OptionsView.ShowGroupPanel = false;
            // 
            // MarketDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDepth);
            this.Controls.Add(this.pnlMD);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(350, 0);
            this.Name = "MarketDataUC";
            this.Size = new System.Drawing.Size(350, 478);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepth)).EndInit();
            this.pnlMD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvInfo)).EndInit();
            this.pnlDepth.ResumeLayout(false);
            this.pnlBids.ResumeLayout(false);
            this.pnlOffers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOffers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOffers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.NumericUpDown txtDepth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.TextBox txtMarketID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMD;
        private DevExpress.XtraGrid.GridControl grdInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvInfo;
        private System.Windows.Forms.Panel pnlDepth;
        private System.Windows.Forms.Panel pnlOffers;
        private DevExpress.XtraGrid.GridControl grdOffers;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOffers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlBids;
        private DevExpress.XtraGrid.GridControl grdBids;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvBids;
        private System.Windows.Forms.Label label4;
    }
}
