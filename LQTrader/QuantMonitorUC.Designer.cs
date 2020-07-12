namespace LQTrader
{
    partial class QuantMonitorUC
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
            this.components = new System.ComponentModel.Container();
            this.pMain = new System.Windows.Forms.Panel();
            this.pAcceptedOpportunities = new System.Windows.Forms.Panel();
            this.gridAcceptedOpportunities = new DevExpress.XtraGrid.GridControl();
            this.gridvAcceptedOpportunities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pAcceptedOpportunitiesTop = new System.Windows.Forms.Panel();
            this.lblAcceptedOpportunities = new System.Windows.Forms.Label();
            this.pOpportunities = new System.Windows.Forms.Panel();
            this.gridOpportunities = new DevExpress.XtraGrid.GridControl();
            this.gridvOpportunities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pOpportunitiesTop = new System.Windows.Forms.Panel();
            this.lblOpportunities = new System.Windows.Forms.Label();
            this.pOpportunitiesTopRight = new System.Windows.Forms.Panel();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dunRefreshSecs = new System.Windows.Forms.NumericUpDown();
            this.pBottom = new System.Windows.Forms.Panel();
            this.pStrategies = new System.Windows.Forms.Panel();
            this.gridStrategies = new DevExpress.XtraGrid.GridControl();
            this.gridvStrategies = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pStrategiesTop = new System.Windows.Forms.Panel();
            this.lblStrategies = new System.Windows.Forms.Label();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.pMain.SuspendLayout();
            this.pAcceptedOpportunities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAcceptedOpportunities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvAcceptedOpportunities)).BeginInit();
            this.pAcceptedOpportunitiesTop.SuspendLayout();
            this.pOpportunities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOpportunities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvOpportunities)).BeginInit();
            this.pOpportunitiesTop.SuspendLayout();
            this.pOpportunitiesTopRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dunRefreshSecs)).BeginInit();
            this.pStrategies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStrategies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvStrategies)).BeginInit();
            this.pStrategiesTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.pAcceptedOpportunities);
            this.pMain.Controls.Add(this.pOpportunities);
            this.pMain.Controls.Add(this.pBottom);
            this.pMain.Controls.Add(this.pStrategies);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(861, 696);
            this.pMain.TabIndex = 0;
            // 
            // pAcceptedOpportunities
            // 
            this.pAcceptedOpportunities.Controls.Add(this.gridAcceptedOpportunities);
            this.pAcceptedOpportunities.Controls.Add(this.pAcceptedOpportunitiesTop);
            this.pAcceptedOpportunities.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pAcceptedOpportunities.Location = new System.Drawing.Point(0, 401);
            this.pAcceptedOpportunities.Name = "pAcceptedOpportunities";
            this.pAcceptedOpportunities.Size = new System.Drawing.Size(861, 261);
            this.pAcceptedOpportunities.TabIndex = 4;
            // 
            // gridAcceptedOpportunities
            // 
            this.gridAcceptedOpportunities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAcceptedOpportunities.Location = new System.Drawing.Point(0, 33);
            this.gridAcceptedOpportunities.MainView = this.gridvAcceptedOpportunities;
            this.gridAcceptedOpportunities.Name = "gridAcceptedOpportunities";
            this.gridAcceptedOpportunities.Size = new System.Drawing.Size(861, 228);
            this.gridAcceptedOpportunities.TabIndex = 2;
            this.gridAcceptedOpportunities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridvAcceptedOpportunities});
            // 
            // gridvAcceptedOpportunities
            // 
            this.gridvAcceptedOpportunities.GridControl = this.gridAcceptedOpportunities;
            this.gridvAcceptedOpportunities.Name = "gridvAcceptedOpportunities";
            // 
            // pAcceptedOpportunitiesTop
            // 
            this.pAcceptedOpportunitiesTop.Controls.Add(this.lblAcceptedOpportunities);
            this.pAcceptedOpportunitiesTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pAcceptedOpportunitiesTop.Location = new System.Drawing.Point(0, 0);
            this.pAcceptedOpportunitiesTop.Name = "pAcceptedOpportunitiesTop";
            this.pAcceptedOpportunitiesTop.Size = new System.Drawing.Size(861, 33);
            this.pAcceptedOpportunitiesTop.TabIndex = 1;
            // 
            // lblAcceptedOpportunities
            // 
            this.lblAcceptedOpportunities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAcceptedOpportunities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceptedOpportunities.Location = new System.Drawing.Point(0, 0);
            this.lblAcceptedOpportunities.Name = "lblAcceptedOpportunities";
            this.lblAcceptedOpportunities.Size = new System.Drawing.Size(861, 33);
            this.lblAcceptedOpportunities.TabIndex = 1;
            this.lblAcceptedOpportunities.Text = "Accepted Opportunities";
            this.lblAcceptedOpportunities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pOpportunities
            // 
            this.pOpportunities.Controls.Add(this.gridOpportunities);
            this.pOpportunities.Controls.Add(this.pOpportunitiesTop);
            this.pOpportunities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pOpportunities.Location = new System.Drawing.Point(0, 235);
            this.pOpportunities.Name = "pOpportunities";
            this.pOpportunities.Size = new System.Drawing.Size(861, 427);
            this.pOpportunities.TabIndex = 3;
            // 
            // gridOpportunities
            // 
            this.gridOpportunities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOpportunities.Location = new System.Drawing.Point(0, 32);
            this.gridOpportunities.MainView = this.gridvOpportunities;
            this.gridOpportunities.Name = "gridOpportunities";
            this.gridOpportunities.Size = new System.Drawing.Size(861, 395);
            this.gridOpportunities.TabIndex = 1;
            this.gridOpportunities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridvOpportunities});
            // 
            // gridvOpportunities
            // 
            this.gridvOpportunities.GridControl = this.gridOpportunities;
            this.gridvOpportunities.Name = "gridvOpportunities";
            // 
            // pOpportunitiesTop
            // 
            this.pOpportunitiesTop.Controls.Add(this.lblOpportunities);
            this.pOpportunitiesTop.Controls.Add(this.pOpportunitiesTopRight);
            this.pOpportunitiesTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pOpportunitiesTop.Location = new System.Drawing.Point(0, 0);
            this.pOpportunitiesTop.Name = "pOpportunitiesTop";
            this.pOpportunitiesTop.Size = new System.Drawing.Size(861, 32);
            this.pOpportunitiesTop.TabIndex = 0;
            // 
            // lblOpportunities
            // 
            this.lblOpportunities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOpportunities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpportunities.Location = new System.Drawing.Point(0, 0);
            this.lblOpportunities.Name = "lblOpportunities";
            this.lblOpportunities.Size = new System.Drawing.Size(654, 32);
            this.lblOpportunities.TabIndex = 2;
            this.lblOpportunities.Text = "                                                    Opportunities";
            this.lblOpportunities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pOpportunitiesTopRight
            // 
            this.pOpportunitiesTopRight.Controls.Add(this.cmdRefresh);
            this.pOpportunitiesTopRight.Controls.Add(this.label1);
            this.pOpportunitiesTopRight.Controls.Add(this.dunRefreshSecs);
            this.pOpportunitiesTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pOpportunitiesTopRight.Location = new System.Drawing.Point(654, 0);
            this.pOpportunitiesTopRight.Name = "pOpportunitiesTopRight";
            this.pOpportunitiesTopRight.Size = new System.Drawing.Size(207, 32);
            this.pOpportunitiesTopRight.TabIndex = 0;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(155, 7);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(45, 23);
            this.cmdRefresh.TabIndex = 2;
            this.cmdRefresh.Text = "Appy";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Refresh seconds";
            // 
            // dunRefreshSecs
            // 
            this.dunRefreshSecs.Location = new System.Drawing.Point(92, 8);
            this.dunRefreshSecs.Name = "dunRefreshSecs";
            this.dunRefreshSecs.Size = new System.Drawing.Size(57, 20);
            this.dunRefreshSecs.TabIndex = 0;
            this.dunRefreshSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dunRefreshSecs.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // pBottom
            // 
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Location = new System.Drawing.Point(0, 662);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(861, 34);
            this.pBottom.TabIndex = 2;
            // 
            // pStrategies
            // 
            this.pStrategies.Controls.Add(this.gridStrategies);
            this.pStrategies.Controls.Add(this.pStrategiesTop);
            this.pStrategies.Dock = System.Windows.Forms.DockStyle.Top;
            this.pStrategies.Location = new System.Drawing.Point(0, 0);
            this.pStrategies.Name = "pStrategies";
            this.pStrategies.Size = new System.Drawing.Size(861, 235);
            this.pStrategies.TabIndex = 0;
            // 
            // gridStrategies
            // 
            this.gridStrategies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStrategies.Location = new System.Drawing.Point(0, 29);
            this.gridStrategies.MainView = this.gridvStrategies;
            this.gridStrategies.Name = "gridStrategies";
            this.gridStrategies.Size = new System.Drawing.Size(861, 206);
            this.gridStrategies.TabIndex = 1;
            this.gridStrategies.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridvStrategies});
            // 
            // gridvStrategies
            // 
            this.gridvStrategies.GridControl = this.gridStrategies;
            this.gridvStrategies.Name = "gridvStrategies";
            this.gridvStrategies.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridvStrategies_CellValueChanged);
            // 
            // pStrategiesTop
            // 
            this.pStrategiesTop.Controls.Add(this.lblStrategies);
            this.pStrategiesTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pStrategiesTop.Location = new System.Drawing.Point(0, 0);
            this.pStrategiesTop.Name = "pStrategiesTop";
            this.pStrategiesTop.Size = new System.Drawing.Size(861, 29);
            this.pStrategiesTop.TabIndex = 0;
            // 
            // lblStrategies
            // 
            this.lblStrategies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStrategies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrategies.Location = new System.Drawing.Point(0, 0);
            this.lblStrategies.Name = "lblStrategies";
            this.lblStrategies.Size = new System.Drawing.Size(861, 29);
            this.lblStrategies.TabIndex = 0;
            this.lblStrategies.Text = "Strategies";
            this.lblStrategies.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // QuantMonitorUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pMain);
            this.Name = "QuantMonitorUC";
            this.Size = new System.Drawing.Size(861, 696);
            this.pMain.ResumeLayout(false);
            this.pAcceptedOpportunities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAcceptedOpportunities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvAcceptedOpportunities)).EndInit();
            this.pAcceptedOpportunitiesTop.ResumeLayout(false);
            this.pOpportunities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOpportunities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvOpportunities)).EndInit();
            this.pOpportunitiesTop.ResumeLayout(false);
            this.pOpportunitiesTopRight.ResumeLayout(false);
            this.pOpportunitiesTopRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dunRefreshSecs)).EndInit();
            this.pStrategies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStrategies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridvStrategies)).EndInit();
            this.pStrategiesTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pOpportunities;
        private System.Windows.Forms.Panel pBottom;
        private System.Windows.Forms.Panel pStrategies;
        private System.Windows.Forms.Panel pStrategiesTop;
        private System.Windows.Forms.Label lblStrategies;
        private DevExpress.XtraGrid.GridControl gridOpportunities;
        private DevExpress.XtraGrid.Views.Grid.GridView gridvOpportunities;
        private System.Windows.Forms.Panel pOpportunitiesTop;
        private DevExpress.XtraGrid.GridControl gridStrategies;
        private DevExpress.XtraGrid.Views.Grid.GridView gridvStrategies;
        private System.Windows.Forms.Panel pAcceptedOpportunities;
        private DevExpress.XtraGrid.GridControl gridAcceptedOpportunities;
        private DevExpress.XtraGrid.Views.Grid.GridView gridvAcceptedOpportunities;
        private System.Windows.Forms.Panel pAcceptedOpportunitiesTop;
        private System.Windows.Forms.Label lblAcceptedOpportunities;
        private System.Windows.Forms.Label lblOpportunities;
        private System.Windows.Forms.Panel pOpportunitiesTopRight;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown dunRefreshSecs;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}
