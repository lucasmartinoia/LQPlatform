namespace LQTrader
{
    partial class InstrumentDetails
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblInstrumentName = new System.Windows.Forms.Label();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblInstrumentName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(292, 41);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.pnlBottom);
            this.pnlGrid.Controls.Add(this.vGridControl1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 41);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(292, 414);
            this.pnlGrid.TabIndex = 1;
            // 
            // lblInstrumentName
            // 
            this.lblInstrumentName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInstrumentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrumentName.Location = new System.Drawing.Point(0, 0);
            this.lblInstrumentName.Name = "lblInstrumentName";
            this.lblInstrumentName.Size = new System.Drawing.Size(292, 41);
            this.lblInstrumentName.TabIndex = 1;
            this.lblInstrumentName.Text = "label1";
            this.lblInstrumentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.OptionsBehavior.Editable = false;
            this.vGridControl1.Size = new System.Drawing.Size(292, 414);
            this.vGridControl1.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.cmdClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 384);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(292, 30);
            this.pnlBottom.TabIndex = 1;
            // 
            // cmdClose
            // 
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.Location = new System.Drawing.Point(0, 0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(292, 30);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // InstrumentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 455);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Name = "InstrumentDetails";
            this.Text = "Instrument Details";
            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblInstrumentName;
        private System.Windows.Forms.Panel pnlGrid;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button cmdClose;
    }
}