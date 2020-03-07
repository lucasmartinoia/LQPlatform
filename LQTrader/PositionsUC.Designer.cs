namespace LQTrader
{
    partial class PositionsUC
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
            this.cmdPositionDetails = new System.Windows.Forms.Button();
            this.cmdPositions = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPositions = new System.Windows.Forms.Panel();
            this.grdPositions = new DevExpress.XtraGrid.GridControl();
            this.grdvPositions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlPositionDetails = new System.Windows.Forms.Panel();
            this.pnlPositionsSD = new System.Windows.Forms.Panel();
            this.pnlPositionsSDDailyDiff = new System.Windows.Forms.Panel();
            this.grdPositionsSDDailyDiff = new DevExpress.XtraGrid.GridControl();
            this.grdvPositionsSDDailyDiff = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlPositionDetails2 = new System.Windows.Forms.Panel();
            this.grdPositionDetails = new DevExpress.XtraGrid.GridControl();
            this.grdvPositionDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label4 = new System.Windows.Forms.Label();
            this.grdPositionsD = new DevExpress.XtraGrid.GridControl();
            this.grdvPositionsD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlPositionDetailsTop = new System.Windows.Forms.Panel();
            this.lblLastCalculation = new System.Windows.Forms.Label();
            this.txtTotalMarketValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalDailyDifference = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositions)).BeginInit();
            this.pnlPositionDetails.SuspendLayout();
            this.pnlPositionsSD.SuspendLayout();
            this.pnlPositionsSDDailyDiff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsSDDailyDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsSDDailyDiff)).BeginInit();
            this.pnlPositionDetails2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsD)).BeginInit();
            this.pnlPositionDetailsTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.cmdPositionDetails);
            this.pnlTop.Controls.Add(this.cmdPositions);
            this.pnlTop.Controls.Add(this.txtAccount);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(764, 37);
            this.pnlTop.TabIndex = 0;
            // 
            // cmdPositionDetails
            // 
            this.cmdPositionDetails.Location = new System.Drawing.Point(281, 8);
            this.cmdPositionDetails.Name = "cmdPositionDetails";
            this.cmdPositionDetails.Size = new System.Drawing.Size(99, 23);
            this.cmdPositionDetails.TabIndex = 3;
            this.cmdPositionDetails.Text = "Position Details";
            this.cmdPositionDetails.UseVisualStyleBackColor = true;
            this.cmdPositionDetails.Click += new System.EventHandler(this.cmdPositionDetails_Click);
            // 
            // cmdPositions
            // 
            this.cmdPositions.Location = new System.Drawing.Point(186, 7);
            this.cmdPositions.Name = "cmdPositions";
            this.cmdPositions.Size = new System.Drawing.Size(75, 23);
            this.cmdPositions.TabIndex = 2;
            this.cmdPositions.Text = "Positions";
            this.cmdPositions.UseVisualStyleBackColor = true;
            this.cmdPositions.Click += new System.EventHandler(this.cmdPositions_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(67, 10);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(100, 20);
            this.txtAccount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account";
            // 
            // pnlPositions
            // 
            this.pnlPositions.Controls.Add(this.grdPositions);
            this.pnlPositions.Location = new System.Drawing.Point(213, 235);
            this.pnlPositions.Name = "pnlPositions";
            this.pnlPositions.Size = new System.Drawing.Size(428, 281);
            this.pnlPositions.TabIndex = 1;
            // 
            // grdPositions
            // 
            this.grdPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPositions.Location = new System.Drawing.Point(0, 0);
            this.grdPositions.MainView = this.grdvPositions;
            this.grdPositions.Name = "grdPositions";
            this.grdPositions.Size = new System.Drawing.Size(428, 281);
            this.grdPositions.TabIndex = 2;
            this.grdPositions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPositions});
            // 
            // grdvPositions
            // 
            this.grdvPositions.GridControl = this.grdPositions;
            this.grdvPositions.Name = "grdvPositions";
            this.grdvPositions.OptionsBehavior.Editable = false;
            this.grdvPositions.OptionsView.ColumnAutoWidth = false;
            // 
            // pnlPositionDetails
            // 
            this.pnlPositionDetails.Controls.Add(this.pnlPositionsSD);
            this.pnlPositionDetails.Controls.Add(this.grdPositionsD);
            this.pnlPositionDetails.Controls.Add(this.pnlPositionDetailsTop);
            this.pnlPositionDetails.Location = new System.Drawing.Point(52, 58);
            this.pnlPositionDetails.Name = "pnlPositionDetails";
            this.pnlPositionDetails.Size = new System.Drawing.Size(564, 458);
            this.pnlPositionDetails.TabIndex = 2;
            // 
            // pnlPositionsSD
            // 
            this.pnlPositionsSD.Controls.Add(this.pnlPositionsSDDailyDiff);
            this.pnlPositionsSD.Controls.Add(this.pnlPositionDetails2);
            this.pnlPositionsSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPositionsSD.Location = new System.Drawing.Point(0, 187);
            this.pnlPositionsSD.Name = "pnlPositionsSD";
            this.pnlPositionsSD.Size = new System.Drawing.Size(564, 271);
            this.pnlPositionsSD.TabIndex = 3;
            // 
            // pnlPositionsSDDailyDiff
            // 
            this.pnlPositionsSDDailyDiff.Controls.Add(this.grdPositionsSDDailyDiff);
            this.pnlPositionsSDDailyDiff.Controls.Add(this.label5);
            this.pnlPositionsSDDailyDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPositionsSDDailyDiff.Location = new System.Drawing.Point(0, 133);
            this.pnlPositionsSDDailyDiff.Name = "pnlPositionsSDDailyDiff";
            this.pnlPositionsSDDailyDiff.Size = new System.Drawing.Size(564, 138);
            this.pnlPositionsSDDailyDiff.TabIndex = 3;
            // 
            // grdPositionsSDDailyDiff
            // 
            this.grdPositionsSDDailyDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPositionsSDDailyDiff.Location = new System.Drawing.Point(0, 23);
            this.grdPositionsSDDailyDiff.MainView = this.grdvPositionsSDDailyDiff;
            this.grdPositionsSDDailyDiff.Name = "grdPositionsSDDailyDiff";
            this.grdPositionsSDDailyDiff.Size = new System.Drawing.Size(564, 115);
            this.grdPositionsSDDailyDiff.TabIndex = 3;
            this.grdPositionsSDDailyDiff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPositionsSDDailyDiff});
            // 
            // grdvPositionsSDDailyDiff
            // 
            this.grdvPositionsSDDailyDiff.GridControl = this.grdPositionsSDDailyDiff;
            this.grdvPositionsSDDailyDiff.Name = "grdvPositionsSDDailyDiff";
            this.grdvPositionsSDDailyDiff.OptionsBehavior.Editable = false;
            this.grdvPositionsSDDailyDiff.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grdvPositionsSDDailyDiff.OptionsFind.ShowSearchNavButtons = false;
            this.grdvPositionsSDDailyDiff.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdvPositionsSDDailyDiff.OptionsView.ColumnAutoWidth = false;
            this.grdvPositionsSDDailyDiff.OptionsView.ShowGroupPanel = false;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(564, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Daily Difference";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPositionDetails2
            // 
            this.pnlPositionDetails2.Controls.Add(this.grdPositionDetails);
            this.pnlPositionDetails2.Controls.Add(this.label4);
            this.pnlPositionDetails2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPositionDetails2.Location = new System.Drawing.Point(0, 0);
            this.pnlPositionDetails2.Name = "pnlPositionDetails2";
            this.pnlPositionDetails2.Size = new System.Drawing.Size(564, 133);
            this.pnlPositionDetails2.TabIndex = 2;
            // 
            // grdPositionDetails
            // 
            this.grdPositionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPositionDetails.Location = new System.Drawing.Point(0, 17);
            this.grdPositionDetails.MainView = this.grdvPositionDetails;
            this.grdPositionDetails.Name = "grdPositionDetails";
            this.grdPositionDetails.Size = new System.Drawing.Size(564, 116);
            this.grdPositionDetails.TabIndex = 4;
            this.grdPositionDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPositionDetails});
            // 
            // grdvPositionDetails
            // 
            this.grdvPositionDetails.GridControl = this.grdPositionDetails;
            this.grdvPositionDetails.Name = "grdvPositionDetails";
            this.grdvPositionDetails.OptionsBehavior.Editable = false;
            this.grdvPositionDetails.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grdvPositionDetails.OptionsFind.ShowSearchNavButtons = false;
            this.grdvPositionDetails.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdvPositionDetails.OptionsView.ColumnAutoWidth = false;
            this.grdvPositionDetails.OptionsView.ShowGroupPanel = false;
            this.grdvPositionDetails.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdvPositionDetails_FocusedRowChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(564, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Details";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdPositionsD
            // 
            this.grdPositionsD.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdPositionsD.Location = new System.Drawing.Point(0, 29);
            this.grdPositionsD.MainView = this.grdvPositionsD;
            this.grdPositionsD.Name = "grdPositionsD";
            this.grdPositionsD.Size = new System.Drawing.Size(564, 158);
            this.grdPositionsD.TabIndex = 2;
            this.grdPositionsD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPositionsD});
            // 
            // grdvPositionsD
            // 
            this.grdvPositionsD.GridControl = this.grdPositionsD;
            this.grdvPositionsD.Name = "grdvPositionsD";
            this.grdvPositionsD.OptionsBehavior.Editable = false;
            this.grdvPositionsD.OptionsView.ColumnAutoWidth = false;
            this.grdvPositionsD.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdvPositionsD_FocusedRowChanged);
            // 
            // pnlPositionDetailsTop
            // 
            this.pnlPositionDetailsTop.Controls.Add(this.lblLastCalculation);
            this.pnlPositionDetailsTop.Controls.Add(this.txtTotalMarketValue);
            this.pnlPositionDetailsTop.Controls.Add(this.label6);
            this.pnlPositionDetailsTop.Controls.Add(this.txtTotalDailyDifference);
            this.pnlPositionDetailsTop.Controls.Add(this.label3);
            this.pnlPositionDetailsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPositionDetailsTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPositionDetailsTop.Name = "pnlPositionDetailsTop";
            this.pnlPositionDetailsTop.Size = new System.Drawing.Size(564, 29);
            this.pnlPositionDetailsTop.TabIndex = 0;
            this.pnlPositionDetailsTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPositionDetailsTop_Paint);
            // 
            // lblLastCalculation
            // 
            this.lblLastCalculation.AutoSize = true;
            this.lblLastCalculation.Location = new System.Drawing.Point(453, 8);
            this.lblLastCalculation.Name = "lblLastCalculation";
            this.lblLastCalculation.Size = new System.Drawing.Size(35, 13);
            this.lblLastCalculation.TabIndex = 5;
            this.lblLastCalculation.Text = "label7";
            // 
            // txtTotalMarketValue
            // 
            this.txtTotalMarketValue.Location = new System.Drawing.Point(335, 5);
            this.txtTotalMarketValue.Name = "txtTotalMarketValue";
            this.txtTotalMarketValue.ReadOnly = true;
            this.txtTotalMarketValue.Size = new System.Drawing.Size(100, 20);
            this.txtTotalMarketValue.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Total Market Value";
            // 
            // txtTotalDailyDifference
            // 
            this.txtTotalDailyDifference.Location = new System.Drawing.Point(121, 5);
            this.txtTotalDailyDifference.Name = "txtTotalDailyDifference";
            this.txtTotalDailyDifference.ReadOnly = true;
            this.txtTotalDailyDifference.Size = new System.Drawing.Size(100, 20);
            this.txtTotalDailyDifference.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total Daily Difference";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(423, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "label7";
            // 
            // PositionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPositions);
            this.Controls.Add(this.pnlPositionDetails);
            this.Controls.Add(this.pnlTop);
            this.Name = "PositionsUC";
            this.Size = new System.Drawing.Size(764, 539);
            this.Load += new System.EventHandler(this.PositionsUC_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlPositions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPositions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositions)).EndInit();
            this.pnlPositionDetails.ResumeLayout(false);
            this.pnlPositionsSD.ResumeLayout(false);
            this.pnlPositionsSDDailyDiff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsSDDailyDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsSDDailyDiff)).EndInit();
            this.pnlPositionDetails2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsD)).EndInit();
            this.pnlPositionDetailsTop.ResumeLayout(false);
            this.pnlPositionDetailsTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdPositionDetails;
        private System.Windows.Forms.Button cmdPositions;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Panel pnlPositions;
        private DevExpress.XtraGrid.GridControl grdPositions;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPositions;
        private System.Windows.Forms.Panel pnlPositionDetails;
        private System.Windows.Forms.Panel pnlPositionDetailsTop;
        private System.Windows.Forms.TextBox txtTotalDailyDifference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlPositionsSD;
        private DevExpress.XtraGrid.GridControl grdPositionsD;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPositionsD;
        private System.Windows.Forms.Panel pnlPositionsSDDailyDiff;
        private DevExpress.XtraGrid.GridControl grdPositionsSDDailyDiff;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPositionsSDDailyDiff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlPositionDetails2;
        private DevExpress.XtraGrid.GridControl grdPositionDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPositionDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLastCalculation;
        private System.Windows.Forms.TextBox txtTotalMarketValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitle;
    }
}
