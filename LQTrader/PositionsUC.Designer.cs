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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.cmdPositions = new System.Windows.Forms.Button();
            this.cmdPositionDetails = new System.Windows.Forms.Button();
            this.pnlPositions = new System.Windows.Forms.Panel();
            this.lblPositions = new System.Windows.Forms.Label();
            this.grdPositions = new DevExpress.XtraGrid.GridControl();
            this.grdvPositions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlPositionDetails = new System.Windows.Forms.Panel();
            this.pnlPositionDetailsTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalDailyDifference = new System.Windows.Forms.TextBox();
            this.grdPositionsD = new DevExpress.XtraGrid.GridControl();
            this.grdvPositionsD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlPositionsSD = new System.Windows.Forms.Panel();
            this.pnlPositionSDSize = new System.Windows.Forms.Panel();
            this.pnlPositionsSDDailyDiff = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grdPositionsSDSize = new DevExpress.XtraGrid.GridControl();
            this.grdvPositionsSDSize = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdPositionsSDDailyDiff = new DevExpress.XtraGrid.GridControl();
            this.grdvPositionsSDDailyDiff = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlTop.SuspendLayout();
            this.pnlPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositions)).BeginInit();
            this.pnlPositionDetails.SuspendLayout();
            this.pnlPositionDetailsTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsD)).BeginInit();
            this.pnlPositionsSD.SuspendLayout();
            this.pnlPositionSDSize.SuspendLayout();
            this.pnlPositionsSDDailyDiff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsSDSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsSDSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsSDDailyDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsSDDailyDiff)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(67, 10);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(100, 20);
            this.txtAccount.TabIndex = 1;
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
            // pnlPositions
            // 
            this.pnlPositions.Controls.Add(this.grdPositions);
            this.pnlPositions.Controls.Add(this.lblPositions);
            this.pnlPositions.Location = new System.Drawing.Point(213, 235);
            this.pnlPositions.Name = "pnlPositions";
            this.pnlPositions.Size = new System.Drawing.Size(428, 281);
            this.pnlPositions.TabIndex = 1;
            // 
            // lblPositions
            // 
            this.lblPositions.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPositions.Location = new System.Drawing.Point(0, 0);
            this.lblPositions.Name = "lblPositions";
            this.lblPositions.Size = new System.Drawing.Size(428, 23);
            this.lblPositions.TabIndex = 0;
            this.lblPositions.Text = "Positions";
            this.lblPositions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdPositions
            // 
            this.grdPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPositions.Location = new System.Drawing.Point(0, 23);
            this.grdPositions.MainView = this.grdvPositions;
            this.grdPositions.Name = "grdPositions";
            this.grdPositions.Size = new System.Drawing.Size(428, 258);
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
            this.pnlPositionDetails.Location = new System.Drawing.Point(52, 91);
            this.pnlPositionDetails.Name = "pnlPositionDetails";
            this.pnlPositionDetails.Size = new System.Drawing.Size(564, 389);
            this.pnlPositionDetails.TabIndex = 2;
            // 
            // pnlPositionDetailsTop
            // 
            this.pnlPositionDetailsTop.Controls.Add(this.txtTotalDailyDifference);
            this.pnlPositionDetailsTop.Controls.Add(this.label3);
            this.pnlPositionDetailsTop.Controls.Add(this.label2);
            this.pnlPositionDetailsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPositionDetailsTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPositionDetailsTop.Name = "pnlPositionDetailsTop";
            this.pnlPositionDetailsTop.Size = new System.Drawing.Size(564, 62);
            this.pnlPositionDetailsTop.TabIndex = 0;
            this.pnlPositionDetailsTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPositionDetailsTop_Paint);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(564, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Position Details";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total Daily Difference";
            // 
            // txtTotalDailyDifference
            // 
            this.txtTotalDailyDifference.Location = new System.Drawing.Point(131, 31);
            this.txtTotalDailyDifference.Name = "txtTotalDailyDifference";
            this.txtTotalDailyDifference.ReadOnly = true;
            this.txtTotalDailyDifference.Size = new System.Drawing.Size(100, 20);
            this.txtTotalDailyDifference.TabIndex = 2;
            // 
            // grdPositionsD
            // 
            this.grdPositionsD.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdPositionsD.Location = new System.Drawing.Point(0, 62);
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
            // 
            // pnlPositionsSD
            // 
            this.pnlPositionsSD.Controls.Add(this.pnlPositionsSDDailyDiff);
            this.pnlPositionsSD.Controls.Add(this.pnlPositionSDSize);
            this.pnlPositionsSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPositionsSD.Location = new System.Drawing.Point(0, 220);
            this.pnlPositionsSD.Name = "pnlPositionsSD";
            this.pnlPositionsSD.Size = new System.Drawing.Size(564, 169);
            this.pnlPositionsSD.TabIndex = 3;
            // 
            // pnlPositionSDSize
            // 
            this.pnlPositionSDSize.Controls.Add(this.grdPositionsSDSize);
            this.pnlPositionSDSize.Controls.Add(this.label4);
            this.pnlPositionSDSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPositionSDSize.Location = new System.Drawing.Point(0, 0);
            this.pnlPositionSDSize.Name = "pnlPositionSDSize";
            this.pnlPositionSDSize.Size = new System.Drawing.Size(261, 169);
            this.pnlPositionSDSize.TabIndex = 0;
            // 
            // pnlPositionsSDDailyDiff
            // 
            this.pnlPositionsSDDailyDiff.Controls.Add(this.grdPositionsSDDailyDiff);
            this.pnlPositionsSDDailyDiff.Controls.Add(this.label5);
            this.pnlPositionsSDDailyDiff.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPositionsSDDailyDiff.Location = new System.Drawing.Point(261, 0);
            this.pnlPositionsSDDailyDiff.Name = "pnlPositionsSDDailyDiff";
            this.pnlPositionsSDDailyDiff.Size = new System.Drawing.Size(266, 169);
            this.pnlPositionsSDDailyDiff.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Size";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Daily Difference";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdPositionsSDSize
            // 
            this.grdPositionsSDSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPositionsSDSize.Location = new System.Drawing.Point(0, 23);
            this.grdPositionsSDSize.MainView = this.grdvPositionsSDSize;
            this.grdPositionsSDSize.Name = "grdPositionsSDSize";
            this.grdPositionsSDSize.Size = new System.Drawing.Size(261, 146);
            this.grdPositionsSDSize.TabIndex = 2;
            this.grdPositionsSDSize.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPositionsSDSize});
            // 
            // grdvPositionsSDSize
            // 
            this.grdvPositionsSDSize.GridControl = this.grdPositionsSDSize;
            this.grdvPositionsSDSize.Name = "grdvPositionsSDSize";
            this.grdvPositionsSDSize.OptionsBehavior.Editable = false;
            this.grdvPositionsSDSize.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grdvPositionsSDSize.OptionsFind.ShowSearchNavButtons = false;
            this.grdvPositionsSDSize.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdvPositionsSDSize.OptionsView.ColumnAutoWidth = false;
            this.grdvPositionsSDSize.OptionsView.ShowGroupPanel = false;
            // 
            // grdPositionsSDDailyDiff
            // 
            this.grdPositionsSDDailyDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPositionsSDDailyDiff.Location = new System.Drawing.Point(0, 23);
            this.grdPositionsSDDailyDiff.MainView = this.grdvPositionsSDDailyDiff;
            this.grdPositionsSDDailyDiff.Name = "grdPositionsSDDailyDiff";
            this.grdPositionsSDDailyDiff.Size = new System.Drawing.Size(266, 146);
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
            // PositionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPositionDetails);
            this.Controls.Add(this.pnlPositions);
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
            this.pnlPositionDetailsTop.ResumeLayout(false);
            this.pnlPositionDetailsTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsD)).EndInit();
            this.pnlPositionsSD.ResumeLayout(false);
            this.pnlPositionSDSize.ResumeLayout(false);
            this.pnlPositionsSDDailyDiff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsSDSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsSDSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionsSDDailyDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPositionsSDDailyDiff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdPositionDetails;
        private System.Windows.Forms.Button cmdPositions;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Panel pnlPositions;
        private System.Windows.Forms.Label lblPositions;
        private DevExpress.XtraGrid.GridControl grdPositions;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPositions;
        private System.Windows.Forms.Panel pnlPositionDetails;
        private System.Windows.Forms.Panel pnlPositionDetailsTop;
        private System.Windows.Forms.TextBox txtTotalDailyDifference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlPositionsSD;
        private System.Windows.Forms.Panel pnlPositionsSDDailyDiff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlPositionSDSize;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl grdPositionsD;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPositionsD;
        private DevExpress.XtraGrid.GridControl grdPositionsSDDailyDiff;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPositionsSDDailyDiff;
        private DevExpress.XtraGrid.GridControl grdPositionsSDSize;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPositionsSDSize;
    }
}
