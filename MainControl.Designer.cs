namespace ITLec.FormXmlManager
{
    partial class MainControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.gbEntities = new System.Windows.Forms.GroupBox();
            this.lblSearchEntity = new System.Windows.Forms.Label();
            this.txtSearchEntity = new System.Windows.Forms.TextBox();
            this.lvEntities = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbCloseThisTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadEntities = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEditFormXml = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportFormXmls = new System.Windows.Forms.ToolStripButton();
            this.tsbImportFormXmls = new System.Windows.Forms.ToolStripDropDownButton();
            this.importFormXmlsFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFormXmlsFromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbFormXmls = new System.Windows.Forms.GroupBox();
            this.lvFormXmls = new System.Windows.Forms.ListView();
            this.columnHeaderSelect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isdefault = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isdesktopenabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.istabletenabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbEntities.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbFormXmls.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEntities
            // 
            this.gbEntities.Controls.Add(this.lblSearchEntity);
            this.gbEntities.Controls.Add(this.txtSearchEntity);
            this.gbEntities.Controls.Add(this.lvEntities);
            this.gbEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEntities.Enabled = false;
            this.gbEntities.Location = new System.Drawing.Point(0, 0);
            this.gbEntities.Margin = new System.Windows.Forms.Padding(4);
            this.gbEntities.Name = "gbEntities";
            this.gbEntities.Padding = new System.Windows.Forms.Padding(4);
            this.gbEntities.Size = new System.Drawing.Size(359, 605);
            this.gbEntities.TabIndex = 89;
            this.gbEntities.TabStop = false;
            this.gbEntities.Text = "Entities";
            // 
            // lblSearchEntity
            // 
            this.lblSearchEntity.AutoSize = true;
            this.lblSearchEntity.Location = new System.Drawing.Point(8, 23);
            this.lblSearchEntity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchEntity.Name = "lblSearchEntity";
            this.lblSearchEntity.Size = new System.Drawing.Size(57, 17);
            this.lblSearchEntity.TabIndex = 81;
            this.lblSearchEntity.Text = "Search:";
            // 
            // txtSearchEntity
            // 
            this.txtSearchEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchEntity.Location = new System.Drawing.Point(75, 20);
            this.txtSearchEntity.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchEntity.Name = "txtSearchEntity";
            this.txtSearchEntity.Size = new System.Drawing.Size(275, 22);
            this.txtSearchEntity.TabIndex = 80;
            this.txtSearchEntity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnSearchKeyUp);
            // 
            // lvEntities
            // 
            this.lvEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvEntities.FullRowSelect = true;
            this.lvEntities.HideSelection = false;
            this.lvEntities.Location = new System.Drawing.Point(8, 52);
            this.lvEntities.Margin = new System.Windows.Forms.Padding(4);
            this.lvEntities.Name = "lvEntities";
            this.lvEntities.Size = new System.Drawing.Size(342, 550);
            this.lvEntities.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvEntities.TabIndex = 79;
            this.lvEntities.UseCompatibleStateImageBehavior = false;
            this.lvEntities.View = System.Windows.Forms.View.Details;
            this.lvEntities.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewColumnClick);
            this.lvEntities.SelectedIndexChanged += new System.EventHandler(this.lvEntities_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Display name";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Logical name";
            this.columnHeader2.Width = 100;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ico_16_1039.gif");
            this.imageList1.Images.SetKeyName(1, "ico_16_1039_advFind.gif");
            this.imageList1.Images.SetKeyName(2, "ico_16_1039_associated.gif");
            this.imageList1.Images.SetKeyName(3, "ico_16_1039_default.gif");
            this.imageList1.Images.SetKeyName(4, "ico_16_1039_lookup.gif");
            this.imageList1.Images.SetKeyName(5, "ico_16_1039_quickFind.gif");
            this.imageList1.Images.SetKeyName(6, "userquery.png");
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseThisTab,
            this.toolStripSeparator2,
            this.tsbLoadEntities,
            this.toolStripSeparator1,
            this.tsbEditFormXml,
            this.toolStripSeparator3,
            this.tsbExportFormXmls,
            this.tsbImportFormXmls});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMain.Size = new System.Drawing.Size(1081, 30);
            this.tsMain.TabIndex = 85;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbCloseThisTab
            // 
            this.tsbCloseThisTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloseThisTab.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseThisTab.Image")));
            this.tsbCloseThisTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseThisTab.Name = "tsbCloseThisTab";
            this.tsbCloseThisTab.Size = new System.Drawing.Size(24, 27);
            this.tsbCloseThisTab.Text = "Close this tab";
            this.tsbCloseThisTab.Click += new System.EventHandler(this.TsbCloseThisTabClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // tsbLoadEntities
            // 
            this.tsbLoadEntities.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadEntities.Image")));
            this.tsbLoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadEntities.Name = "tsbLoadEntities";
            this.tsbLoadEntities.Size = new System.Drawing.Size(118, 27);
            this.tsbLoadEntities.Text = "Load Entities";
            this.tsbLoadEntities.Click += new System.EventHandler(this.TsbLoadEntitiesClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // tsbEditFormXml
            // 
            this.tsbEditFormXml.Enabled = false;
            this.tsbEditFormXml.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditFormXml.Image")));
            this.tsbEditFormXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditFormXml.Name = "tsbEditFormXml";
            this.tsbEditFormXml.Size = new System.Drawing.Size(123, 27);
            this.tsbEditFormXml.Text = "Edit FormXml";
            this.tsbEditFormXml.ToolTipText = "Edit selected formXml";
            this.tsbEditFormXml.Click += new System.EventHandler(this.tsbEditFormXml_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // tsbExportFormXmls
            // 
            this.tsbExportFormXmls.Enabled = false;
            this.tsbExportFormXmls.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportFormXmls.Image")));
            this.tsbExportFormXmls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportFormXmls.Name = "tsbExportFormXmls";
            this.tsbExportFormXmls.Size = new System.Drawing.Size(144, 27);
            this.tsbExportFormXmls.Text = "Export formXmls";
            this.tsbExportFormXmls.ToolTipText = "Export formXmls that have been checked in formXmls list";
            this.tsbExportFormXmls.Visible = false;
            this.tsbExportFormXmls.Click += new System.EventHandler(this.tsbExportFormXmls_Click);
            // 
            // tsbImportFormXmls
            // 
            this.tsbImportFormXmls.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFormXmlsFromFileToolStripMenuItem,
            this.importFormXmlsFromFolderToolStripMenuItem});
            this.tsbImportFormXmls.Image = ((System.Drawing.Image)(resources.GetObject("tsbImportFormXmls.Image")));
            this.tsbImportFormXmls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImportFormXmls.Name = "tsbImportFormXmls";
            this.tsbImportFormXmls.Size = new System.Drawing.Size(156, 27);
            this.tsbImportFormXmls.Text = "Import formXmls";
            this.tsbImportFormXmls.Visible = false;
            // 
            // importFormXmlsFromFileToolStripMenuItem
            // 
            this.importFormXmlsFromFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importFormXmlsFromFileToolStripMenuItem.Image")));
            this.importFormXmlsFromFileToolStripMenuItem.Name = "importFormXmlsFromFileToolStripMenuItem";
            this.importFormXmlsFromFileToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.importFormXmlsFromFileToolStripMenuItem.Text = "From file";
            this.importFormXmlsFromFileToolStripMenuItem.ToolTipText = "Import one formXml from one formXml file definition file";
            this.importFormXmlsFromFileToolStripMenuItem.Click += new System.EventHandler(this.importFormXmlsFromFileToolStripMenuItem_Click);
            // 
            // importFormXmlsFromFolderToolStripMenuItem
            // 
            this.importFormXmlsFromFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importFormXmlsFromFolderToolStripMenuItem.Image")));
            this.importFormXmlsFromFolderToolStripMenuItem.Name = "importFormXmlsFromFolderToolStripMenuItem";
            this.importFormXmlsFromFolderToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.importFormXmlsFromFolderToolStripMenuItem.Text = "From folder";
            this.importFormXmlsFromFolderToolStripMenuItem.ToolTipText = "Import one or multiple formXmls from formXml definition files contained in a fold" +
    "er";
            this.importFormXmlsFromFolderToolStripMenuItem.Click += new System.EventHandler(this.importFormXmlsFromFolderToolStripMenuItem_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Icon.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbEntities);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbFormXmls);
            this.splitContainer1.Size = new System.Drawing.Size(1081, 605);
            this.splitContainer1.SplitterDistance = 359;
            this.splitContainer1.TabIndex = 90;
            // 
            // gbFormXmls
            // 
            this.gbFormXmls.Controls.Add(this.lvFormXmls);
            this.gbFormXmls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFormXmls.Location = new System.Drawing.Point(0, 0);
            this.gbFormXmls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFormXmls.Name = "gbFormXmls";
            this.gbFormXmls.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFormXmls.Size = new System.Drawing.Size(718, 605);
            this.gbFormXmls.TabIndex = 0;
            this.gbFormXmls.TabStop = false;
            this.gbFormXmls.Text = "FormXmls";
            // 
            // lvFormXmls
            // 
            this.lvFormXmls.CheckBoxes = true;
            this.lvFormXmls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSelect,
            this.columnHeaderName,
            this.isdefault,
            this.isdesktopenabled,
            this.istabletenabled,
            this.columnHeader5});
            this.lvFormXmls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFormXmls.FullRowSelect = true;
            this.lvFormXmls.HoverSelection = true;
            this.lvFormXmls.Location = new System.Drawing.Point(3, 17);
            this.lvFormXmls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvFormXmls.Name = "lvFormXmls";
            this.lvFormXmls.Size = new System.Drawing.Size(712, 586);
            this.lvFormXmls.TabIndex = 0;
            this.lvFormXmls.UseCompatibleStateImageBehavior = false;
            this.lvFormXmls.View = System.Windows.Forms.View.Details;
            this.lvFormXmls.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewColumnClick);
            // 
            // columnHeaderSelect
            // 
            this.columnHeaderSelect.Text = "";
            this.columnHeaderSelect.Width = 40;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 233;
            // 
            // isdefault
            // 
            this.isdefault.Text = "Is Default";
            // 
            // isdesktopenabled
            // 
            this.isdesktopenabled.Text = "Is Desktop Enabled";
            this.isdesktopenabled.Width = 116;
            // 
            // istabletenabled
            // 
            this.istabletenabled.Text = "Is Tablet Enabled";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            this.columnHeader5.Width = 306;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(1081, 635);
            this.gbEntities.ResumeLayout(false);
            this.gbEntities.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbFormXmls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEntities;
        private System.Windows.Forms.ListView lvEntities;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbLoadEntities;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStripButton tsbCloseThisTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox txtSearchEntity;
		private System.Windows.Forms.Label lblSearchEntity;
        private System.Windows.Forms.GroupBox gbFormXmls;
        private System.Windows.Forms.ListView lvFormXmls;
        private System.Windows.Forms.ColumnHeader columnHeaderSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbExportFormXmls;
        private System.Windows.Forms.ToolStripDropDownButton tsbImportFormXmls;
        private System.Windows.Forms.ToolStripMenuItem importFormXmlsFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFormXmlsFromFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbEditFormXml;
        private System.Windows.Forms.ColumnHeader isdesktopenabled;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader isdefault;
        private System.Windows.Forms.ColumnHeader istabletenabled;
    }
}
