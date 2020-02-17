namespace LQTrader
{
    partial class TraderView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraderView));
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer3 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.cmdConnect = new DevExpress.XtraBars.BarButtonItem();
            this.cmdDisconnect = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.txtStatusBar = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dpMarketData = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dpOrder = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpAccountReport = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel4_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dpMarketDataHistoric = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel5_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpPositions = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel6_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpInstruments = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpBlotter = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel7_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpOpportunities = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel8_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.dpMarketData.SuspendLayout();
            this.hideContainerRight.SuspendLayout();
            this.dpOrder.SuspendLayout();
            this.dpAccountReport.SuspendLayout();
            this.hideContainerBottom.SuspendLayout();
            this.dpMarketDataHistoric.SuspendLayout();
            this.dpPositions.SuspendLayout();
            this.dpInstruments.SuspendLayout();
            this.dpBlotter.SuspendLayout();
            this.dpOpportunities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document1,
            this.document2});
            // 
            // document1
            // 
            this.document1.Caption = "Blotter";
            this.document1.ControlName = "dpBlotter";
            this.document1.FloatLocation = new System.Drawing.Point(766, 352);
            this.document1.FloatSize = new System.Drawing.Size(200, 200);
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document2
            // 
            this.document2.Caption = "Opportunities";
            this.document2.ControlName = "dpOpportunities";
            this.document2.FloatLocation = new System.Drawing.Point(749, 353);
            this.document2.FloatSize = new System.Drawing.Size(200, 200);
            this.document2.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.MenuManager = this.barManager1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.cmdConnect,
            this.txtStatusBar,
            this.cmdDisconnect});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdConnect),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdDisconnect)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // cmdConnect
            // 
            this.cmdConnect.Caption = "Login";
            this.cmdConnect.Id = 1;
            this.cmdConnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.cmdConnect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.Caption = "Logout";
            this.cmdDisconnect.Id = 3;
            this.cmdDisconnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.cmdDisconnect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdDisconnect_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.txtStatusBar)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // txtStatusBar
            // 
            this.txtStatusBar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.txtStatusBar.Caption = "txtStatusBar";
            this.txtStatusBar.Id = 2;
            this.txtStatusBar.Name = "txtStatusBar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1078, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 529);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1078, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 505);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1078, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 505);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft,
            this.hideContainerRight,
            this.hideContainerBottom});
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpInstruments,
            this.dpBlotter,
            this.dpOpportunities});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.SystemColors.Control;
            this.hideContainerLeft.Controls.Add(this.dpMarketData);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 24);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(21, 505);
            // 
            // dpMarketData
            // 
            this.dpMarketData.Controls.Add(this.dockPanel2_Container);
            this.dpMarketData.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpMarketData.ID = new System.Guid("0ea9f5a3-a824-42f2-bd0f-b0ec5ab61b37");
            this.dpMarketData.Location = new System.Drawing.Point(0, 0);
            this.dpMarketData.Name = "dpMarketData";
            this.dpMarketData.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpMarketData.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpMarketData.SavedIndex = 0;
            this.dpMarketData.Size = new System.Drawing.Size(200, 545);
            this.dpMarketData.Text = "Market Data";
            this.dpMarketData.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(193, 516);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.SystemColors.Control;
            this.hideContainerRight.Controls.Add(this.dpOrder);
            this.hideContainerRight.Controls.Add(this.dpAccountReport);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1057, 24);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(21, 505);
            // 
            // dpOrder
            // 
            this.dpOrder.Controls.Add(this.dockPanel3_Container);
            this.dpOrder.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpOrder.ID = new System.Guid("85b59891-c2aa-48ab-864c-fca2e660bec3");
            this.dpOrder.Location = new System.Drawing.Point(0, 0);
            this.dpOrder.Name = "dpOrder";
            this.dpOrder.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpOrder.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpOrder.SavedIndex = 1;
            this.dpOrder.Size = new System.Drawing.Size(200, 450);
            this.dpOrder.Text = "Order";
            this.dpOrder.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 26);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(193, 421);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dpAccountReport
            // 
            this.dpAccountReport.Controls.Add(this.dockPanel4_Container);
            this.dpAccountReport.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpAccountReport.ID = new System.Guid("3d121de3-0214-4226-b535-65fc2b709d26");
            this.dpAccountReport.Location = new System.Drawing.Point(0, 0);
            this.dpAccountReport.Name = "dpAccountReport";
            this.dpAccountReport.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpAccountReport.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpAccountReport.SavedIndex = 1;
            this.dpAccountReport.Size = new System.Drawing.Size(200, 545);
            this.dpAccountReport.Text = "Account Report";
            this.dpAccountReport.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel4_Container
            // 
            this.dockPanel4_Container.Location = new System.Drawing.Point(4, 26);
            this.dockPanel4_Container.Name = "dockPanel4_Container";
            this.dockPanel4_Container.Size = new System.Drawing.Size(193, 516);
            this.dockPanel4_Container.TabIndex = 0;
            // 
            // hideContainerBottom
            // 
            this.hideContainerBottom.BackColor = System.Drawing.SystemColors.Control;
            this.hideContainerBottom.Controls.Add(this.dpMarketDataHistoric);
            this.hideContainerBottom.Controls.Add(this.dpPositions);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(21, 508);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(1036, 21);
            // 
            // dpMarketDataHistoric
            // 
            this.dpMarketDataHistoric.Controls.Add(this.dockPanel5_Container);
            this.dpMarketDataHistoric.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpMarketDataHistoric.ID = new System.Guid("e0247011-13f7-425d-81bb-0452671ba887");
            this.dpMarketDataHistoric.Location = new System.Drawing.Point(0, 0);
            this.dpMarketDataHistoric.Name = "dpMarketDataHistoric";
            this.dpMarketDataHistoric.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpMarketDataHistoric.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpMarketDataHistoric.SavedIndex = 2;
            this.dpMarketDataHistoric.Size = new System.Drawing.Size(758, 200);
            this.dpMarketDataHistoric.Text = "Historic Market Data";
            this.dpMarketDataHistoric.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel5_Container
            // 
            this.dockPanel5_Container.Location = new System.Drawing.Point(3, 27);
            this.dockPanel5_Container.Name = "dockPanel5_Container";
            this.dockPanel5_Container.Size = new System.Drawing.Size(752, 170);
            this.dockPanel5_Container.TabIndex = 0;
            // 
            // dpPositions
            // 
            this.dpPositions.Controls.Add(this.dockPanel6_Container);
            this.dpPositions.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpPositions.ID = new System.Guid("3e5fcd2d-45c1-4986-8e5e-4bc5f3e4de3e");
            this.dpPositions.Location = new System.Drawing.Point(0, 0);
            this.dpPositions.Name = "dpPositions";
            this.dpPositions.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpPositions.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpPositions.SavedIndex = 0;
            this.dpPositions.Size = new System.Drawing.Size(1036, 200);
            this.dpPositions.Text = "Positions";
            this.dpPositions.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel6_Container
            // 
            this.dockPanel6_Container.Location = new System.Drawing.Point(3, 27);
            this.dockPanel6_Container.Name = "dockPanel6_Container";
            this.dockPanel6_Container.Size = new System.Drawing.Size(1030, 170);
            this.dockPanel6_Container.TabIndex = 0;
            // 
            // dpInstruments
            // 
            this.dpInstruments.Controls.Add(this.dockPanel1_Container);
            this.dpInstruments.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpInstruments.ID = new System.Guid("362dc0ee-d9fa-42ec-a9e3-deebd86aa18a");
            this.dpInstruments.Location = new System.Drawing.Point(21, 24);
            this.dpInstruments.Name = "dpInstruments";
            this.dpInstruments.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpInstruments.Size = new System.Drawing.Size(200, 484);
            this.dpInstruments.Text = "Instruments";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(193, 455);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dpBlotter
            // 
            this.dpBlotter.Controls.Add(this.dockPanel7_Container);
            this.dpBlotter.DockedAsTabbedDocument = true;
            this.dpBlotter.FloatLocation = new System.Drawing.Point(766, 352);
            this.dpBlotter.ID = new System.Guid("e1eec67e-42f7-4008-9085-c5195db79c86");
            this.dpBlotter.Name = "dpBlotter";
            this.dpBlotter.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpBlotter.Text = "Blotter";
            // 
            // dockPanel7_Container
            // 
            this.dockPanel7_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel7_Container.Name = "dockPanel7_Container";
            this.dockPanel7_Container.Size = new System.Drawing.Size(830, 455);
            this.dockPanel7_Container.TabIndex = 0;
            // 
            // dpOpportunities
            // 
            this.dpOpportunities.Controls.Add(this.dockPanel8_Container);
            this.dpOpportunities.DockedAsTabbedDocument = true;
            this.dpOpportunities.FloatLocation = new System.Drawing.Point(749, 353);
            this.dpOpportunities.ID = new System.Guid("c0cac994-cb36-4151-b29d-2dbfcd7f1ca8");
            this.dpOpportunities.Name = "dpOpportunities";
            this.dpOpportunities.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpOpportunities.Text = "Opportunities";
            // 
            // dockPanel8_Container
            // 
            this.dockPanel8_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel8_Container.Name = "dockPanel8_Container";
            this.dockPanel8_Container.Size = new System.Drawing.Size(830, 455);
            this.dockPanel8_Container.TabIndex = 0;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 0;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
            this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1,
            this.document2});
            this.tabbedView1.Orientation = System.Windows.Forms.Orientation.Vertical;
            dockingContainer3.Element = this.documentGroup1;
            this.tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer3});
            this.tabbedView1.RootContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // TraderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 551);
            this.Controls.Add(this.dpInstruments);
            this.Controls.Add(this.hideContainerBottom);
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.hideContainerRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TraderView";
            this.ShowIcon = false;
            this.Text = "LatamQuants Trader v1.5";
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.dpMarketData.ResumeLayout(false);
            this.hideContainerRight.ResumeLayout(false);
            this.dpOrder.ResumeLayout(false);
            this.dpAccountReport.ResumeLayout(false);
            this.hideContainerBottom.ResumeLayout(false);
            this.dpMarketDataHistoric.ResumeLayout(false);
            this.dpPositions.ResumeLayout(false);
            this.dpInstruments.ResumeLayout(false);
            this.dpBlotter.ResumeLayout(false);
            this.dpOpportunities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dpInstruments;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
        private DevExpress.XtraBars.Docking.DockPanel dpMarketDataHistoric;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel5_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpPositions;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel6_Container;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
        private DevExpress.XtraBars.Docking.DockPanel dpMarketData;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.Docking.DockPanel dpOrder;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpAccountReport;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel4_Container;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document2;
        private DevExpress.XtraBars.Docking.DockPanel dpBlotter;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel7_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpOpportunities;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel8_Container;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem cmdConnect;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarStaticItem txtStatusBar;
        private DevExpress.XtraBars.BarButtonItem cmdDisconnect;
    }
}

