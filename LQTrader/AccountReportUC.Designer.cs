namespace LQTrader
{
    partial class AccountReportUC
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
            this.lblLastCalculation = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cmdAccountReport = new System.Windows.Forms.Button();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.grdAccountValue = new DevExpress.XtraGrid.GridControl();
            this.grdvAccountValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label13 = new System.Windows.Forms.Label();
            this.grdCurrencyBalance = new DevExpress.XtraGrid.GridControl();
            this.grdvCurrencyBalance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlReportTop = new System.Windows.Forms.Panel();
            this.txtDailyDifference = new System.Windows.Forms.TextBox();
            this.txtPortfolio = new System.Windows.Forms.TextBox();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.txtMarginUncovered = new System.Windows.Forms.TextBox();
            this.txtMarginOrders = new System.Windows.Forms.TextBox();
            this.txtMargin = new System.Windows.Forms.TextBox();
            this.txtCollateralAvailable = new System.Windows.Forms.TextBox();
            this.txtCollateral = new System.Windows.Forms.TextBox();
            this.txtMarketMemberIdentity = new System.Windows.Forms.TextBox();
            this.txtMarketMember = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccountValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAccountValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrencyBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvCurrencyBalance)).BeginInit();
            this.pnlReportTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblLastCalculation);
            this.pnlTop.Controls.Add(this.txtAccount);
            this.pnlTop.Controls.Add(this.lblAccount);
            this.pnlTop.Controls.Add(this.cmdAccountReport);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(657, 35);
            this.pnlTop.TabIndex = 0;
            // 
            // lblLastCalculation
            // 
            this.lblLastCalculation.AutoSize = true;
            this.lblLastCalculation.Location = new System.Drawing.Point(309, 12);
            this.lblLastCalculation.Name = "lblLastCalculation";
            this.lblLastCalculation.Size = new System.Drawing.Size(35, 13);
            this.lblLastCalculation.TabIndex = 3;
            this.lblLastCalculation.Text = "label2";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(200, 9);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(93, 20);
            this.txtAccount.TabIndex = 2;
            this.txtAccount.Visible = false;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(151, 12);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(47, 13);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "Account";
            this.lblAccount.Visible = false;
            // 
            // cmdAccountReport
            // 
            this.cmdAccountReport.Location = new System.Drawing.Point(12, 7);
            this.cmdAccountReport.Name = "cmdAccountReport";
            this.cmdAccountReport.Size = new System.Drawing.Size(116, 23);
            this.cmdAccountReport.TabIndex = 0;
            this.cmdAccountReport.Text = "Account Report";
            this.cmdAccountReport.UseVisualStyleBackColor = true;
            this.cmdAccountReport.Click += new System.EventHandler(this.cmdAccountReport_Click);
            // 
            // pnlReport
            // 
            this.pnlReport.Controls.Add(this.grdAccountValue);
            this.pnlReport.Controls.Add(this.label13);
            this.pnlReport.Controls.Add(this.grdCurrencyBalance);
            this.pnlReport.Controls.Add(this.label12);
            this.pnlReport.Controls.Add(this.pnlReportTop);
            this.pnlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReport.Location = new System.Drawing.Point(0, 35);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(657, 457);
            this.pnlReport.TabIndex = 1;
            // 
            // grdAccountValue
            // 
            this.grdAccountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAccountValue.Location = new System.Drawing.Point(0, 326);
            this.grdAccountValue.MainView = this.grdvAccountValue;
            this.grdAccountValue.Name = "grdAccountValue";
            this.grdAccountValue.Size = new System.Drawing.Size(657, 131);
            this.grdAccountValue.TabIndex = 7;
            this.grdAccountValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAccountValue});
            // 
            // grdvAccountValue
            // 
            this.grdvAccountValue.GridControl = this.grdAccountValue;
            this.grdvAccountValue.Name = "grdvAccountValue";
            this.grdvAccountValue.OptionsBehavior.Editable = false;
            this.grdvAccountValue.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grdvAccountValue.OptionsFind.ShowSearchNavButtons = false;
            this.grdvAccountValue.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdvAccountValue.OptionsView.ColumnAutoWidth = false;
            this.grdvAccountValue.OptionsView.ShowGroupPanel = false;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Location = new System.Drawing.Point(0, 302);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(657, 24);
            this.label13.TabIndex = 6;
            this.label13.Text = "Account Value";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdCurrencyBalance
            // 
            this.grdCurrencyBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdCurrencyBalance.Location = new System.Drawing.Point(0, 155);
            this.grdCurrencyBalance.MainView = this.grdvCurrencyBalance;
            this.grdCurrencyBalance.Name = "grdCurrencyBalance";
            this.grdCurrencyBalance.Size = new System.Drawing.Size(657, 147);
            this.grdCurrencyBalance.TabIndex = 5;
            this.grdCurrencyBalance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvCurrencyBalance});
            // 
            // grdvCurrencyBalance
            // 
            this.grdvCurrencyBalance.GridControl = this.grdCurrencyBalance;
            this.grdvCurrencyBalance.Name = "grdvCurrencyBalance";
            this.grdvCurrencyBalance.OptionsBehavior.Editable = false;
            this.grdvCurrencyBalance.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grdvCurrencyBalance.OptionsFind.ShowSearchNavButtons = false;
            this.grdvCurrencyBalance.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdvCurrencyBalance.OptionsView.ColumnAutoWidth = false;
            this.grdvCurrencyBalance.OptionsView.ShowGroupPanel = false;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(0, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(657, 24);
            this.label12.TabIndex = 4;
            this.label12.Text = "Currency Balance";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlReportTop
            // 
            this.pnlReportTop.Controls.Add(this.txtDailyDifference);
            this.pnlReportTop.Controls.Add(this.txtPortfolio);
            this.pnlReportTop.Controls.Add(this.txtCash);
            this.pnlReportTop.Controls.Add(this.txtMarginUncovered);
            this.pnlReportTop.Controls.Add(this.txtMarginOrders);
            this.pnlReportTop.Controls.Add(this.txtMargin);
            this.pnlReportTop.Controls.Add(this.txtCollateralAvailable);
            this.pnlReportTop.Controls.Add(this.txtCollateral);
            this.pnlReportTop.Controls.Add(this.txtMarketMemberIdentity);
            this.pnlReportTop.Controls.Add(this.txtMarketMember);
            this.pnlReportTop.Controls.Add(this.label11);
            this.pnlReportTop.Controls.Add(this.label10);
            this.pnlReportTop.Controls.Add(this.label9);
            this.pnlReportTop.Controls.Add(this.label8);
            this.pnlReportTop.Controls.Add(this.label7);
            this.pnlReportTop.Controls.Add(this.label6);
            this.pnlReportTop.Controls.Add(this.label5);
            this.pnlReportTop.Controls.Add(this.label4);
            this.pnlReportTop.Controls.Add(this.label3);
            this.pnlReportTop.Controls.Add(this.label2);
            this.pnlReportTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportTop.Location = new System.Drawing.Point(0, 0);
            this.pnlReportTop.Name = "pnlReportTop";
            this.pnlReportTop.Size = new System.Drawing.Size(657, 131);
            this.pnlReportTop.TabIndex = 0;
            // 
            // txtDailyDifference
            // 
            this.txtDailyDifference.Location = new System.Drawing.Point(550, 103);
            this.txtDailyDifference.Name = "txtDailyDifference";
            this.txtDailyDifference.ReadOnly = true;
            this.txtDailyDifference.Size = new System.Drawing.Size(91, 20);
            this.txtDailyDifference.TabIndex = 19;
            // 
            // txtPortfolio
            // 
            this.txtPortfolio.Location = new System.Drawing.Point(307, 103);
            this.txtPortfolio.Name = "txtPortfolio";
            this.txtPortfolio.ReadOnly = true;
            this.txtPortfolio.Size = new System.Drawing.Size(91, 20);
            this.txtPortfolio.TabIndex = 18;
            // 
            // txtCash
            // 
            this.txtCash.Location = new System.Drawing.Point(96, 103);
            this.txtCash.Name = "txtCash";
            this.txtCash.ReadOnly = true;
            this.txtCash.Size = new System.Drawing.Size(91, 20);
            this.txtCash.TabIndex = 17;
            // 
            // txtMarginUncovered
            // 
            this.txtMarginUncovered.Location = new System.Drawing.Point(550, 71);
            this.txtMarginUncovered.Name = "txtMarginUncovered";
            this.txtMarginUncovered.ReadOnly = true;
            this.txtMarginUncovered.Size = new System.Drawing.Size(91, 20);
            this.txtMarginUncovered.TabIndex = 16;
            // 
            // txtMarginOrders
            // 
            this.txtMarginOrders.Location = new System.Drawing.Point(307, 71);
            this.txtMarginOrders.Name = "txtMarginOrders";
            this.txtMarginOrders.ReadOnly = true;
            this.txtMarginOrders.Size = new System.Drawing.Size(91, 20);
            this.txtMarginOrders.TabIndex = 15;
            // 
            // txtMargin
            // 
            this.txtMargin.Location = new System.Drawing.Point(96, 71);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.ReadOnly = true;
            this.txtMargin.Size = new System.Drawing.Size(91, 20);
            this.txtMargin.TabIndex = 14;
            // 
            // txtCollateralAvailable
            // 
            this.txtCollateralAvailable.Location = new System.Drawing.Point(307, 41);
            this.txtCollateralAvailable.Name = "txtCollateralAvailable";
            this.txtCollateralAvailable.ReadOnly = true;
            this.txtCollateralAvailable.Size = new System.Drawing.Size(91, 20);
            this.txtCollateralAvailable.TabIndex = 13;
            // 
            // txtCollateral
            // 
            this.txtCollateral.Location = new System.Drawing.Point(96, 41);
            this.txtCollateral.Name = "txtCollateral";
            this.txtCollateral.ReadOnly = true;
            this.txtCollateral.Size = new System.Drawing.Size(91, 20);
            this.txtCollateral.TabIndex = 12;
            // 
            // txtMarketMemberIdentity
            // 
            this.txtMarketMemberIdentity.Location = new System.Drawing.Point(307, 10);
            this.txtMarketMemberIdentity.Name = "txtMarketMemberIdentity";
            this.txtMarketMemberIdentity.ReadOnly = true;
            this.txtMarketMemberIdentity.Size = new System.Drawing.Size(127, 20);
            this.txtMarketMemberIdentity.TabIndex = 11;
            // 
            // txtMarketMember
            // 
            this.txtMarketMember.Location = new System.Drawing.Point(96, 10);
            this.txtMarketMember.Name = "txtMarketMember";
            this.txtMarketMember.ReadOnly = true;
            this.txtMarketMember.Size = new System.Drawing.Size(127, 20);
            this.txtMarketMember.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(260, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Identity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Market Member";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(449, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Margin Uncovered";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Portfolio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Cash";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Margin Orders";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Daily Difference";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Available";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Margin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Collateral";
            // 
            // AccountReportUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.pnlTop);
            this.Name = "AccountReportUC";
            this.Size = new System.Drawing.Size(657, 492);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAccountValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAccountValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrencyBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvCurrencyBalance)).EndInit();
            this.pnlReportTop.ResumeLayout(false);
            this.pnlReportTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblLastCalculation;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button cmdAccountReport;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Panel pnlReportTop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMarketMember;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDailyDifference;
        private System.Windows.Forms.TextBox txtPortfolio;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.TextBox txtMarginUncovered;
        private System.Windows.Forms.TextBox txtMarginOrders;
        private System.Windows.Forms.TextBox txtMargin;
        private System.Windows.Forms.TextBox txtCollateralAvailable;
        private System.Windows.Forms.TextBox txtCollateral;
        private System.Windows.Forms.TextBox txtMarketMemberIdentity;
        private DevExpress.XtraGrid.GridControl grdCurrencyBalance;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvCurrencyBalance;
        private DevExpress.XtraGrid.GridControl grdAccountValue;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAccountValue;
        private System.Windows.Forms.Label label13;
    }
}
