﻿namespace ITLec.FormXmlManager.Forms
{
    partial class FormXmlEditor
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDeleteFormXml = new System.Windows.Forms.Button();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.btnUpdatePublish = new System.Windows.Forms.Button();
            this.btnlVisualEditor = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTxtParent = new System.Windows.Forms.Panel();
            this.tecVisualizationDescription = new ICSharpCode.TextEditor.TextEditorControl();
            this.panelStatistics = new System.Windows.Forms.Panel();
            this.buttonUpdateStatistics = new System.Windows.Forms.Button();
            this.listViewControlsAnalysis = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ddlNewGuid = new System.Windows.Forms.ComboBox();
            this.btnGenerateNewGuid = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTxtParent.SuspendLayout();
            this.panelStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(836, 46);
            this.pnlTitle.TabIndex = 0;
            this.pnlTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTitle_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "FormXml Editor";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGenerateNewGuid);
            this.panel2.Controls.Add(this.ddlNewGuid);
            this.panel2.Controls.Add(this.buttonDeleteFormXml);
            this.panel2.Controls.Add(this.buttonSaveAs);
            this.panel2.Controls.Add(this.btnUpdatePublish);
            this.panel2.Controls.Add(this.btnlVisualEditor);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 514);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 33);
            this.panel2.TabIndex = 1;
            // 
            // buttonDeleteFormXml
            // 
            this.buttonDeleteFormXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteFormXml.Location = new System.Drawing.Point(549, 3);
            this.buttonDeleteFormXml.Name = "buttonDeleteFormXml";
            this.buttonDeleteFormXml.Size = new System.Drawing.Size(96, 23);
            this.buttonDeleteFormXml.TabIndex = 10;
            this.buttonDeleteFormXml.Text = "Delete FormXml";
            this.buttonDeleteFormXml.UseVisualStyleBackColor = true;
            this.buttonDeleteFormXml.Click += new System.EventHandler(this.buttonDeleteFormXml_Click);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveAs.Location = new System.Drawing.Point(653, 3);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(96, 23);
            this.buttonSaveAs.TabIndex = 9;
            this.buttonSaveAs.Text = "Save As";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Visible = false;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // btnUpdatePublish
            // 
            this.btnUpdatePublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePublish.Location = new System.Drawing.Point(444, 3);
            this.btnUpdatePublish.Name = "btnUpdatePublish";
            this.btnUpdatePublish.Size = new System.Drawing.Size(96, 23);
            this.btnUpdatePublish.TabIndex = 8;
            this.btnUpdatePublish.Text = "Update && Publish";
            this.btnUpdatePublish.UseVisualStyleBackColor = true;
            this.btnUpdatePublish.Click += new System.EventHandler(this.btnUpdatePublish_Click);
            // 
            // btnlVisualEditor
            // 
            this.btnlVisualEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlVisualEditor.Location = new System.Drawing.Point(295, 3);
            this.btnlVisualEditor.Name = "btnlVisualEditor";
            this.btnlVisualEditor.Size = new System.Drawing.Size(62, 23);
            this.btnlVisualEditor.TabIndex = 7;
            this.btnlVisualEditor.Text = "Open Visual Editor";
            this.btnlVisualEditor.UseVisualStyleBackColor = true;
            this.btnlVisualEditor.Visible = false;
            this.btnlVisualEditor.Click += new System.EventHandler(this.btnlVisualEditor_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(362, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(757, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblDesc);
            this.panel3.Controls.Add(this.lblName);
            this.panel3.Controls.Add(this.txtDescription);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 46);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(836, 45);
            this.panel3.TabIndex = 10;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(7, 26);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 12;
            this.lblDesc.Text = "Description";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 6);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(104, 24);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(727, 20);
            this.txtDescription.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(104, 4);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(727, 20);
            this.txtName.TabIndex = 9;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelTxtParent);
            this.panel1.Controls.Add(this.panelStatistics);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 423);
            this.panel1.TabIndex = 11;
            // 
            // panelTxtParent
            // 
            this.panelTxtParent.Controls.Add(this.tecVisualizationDescription);
            this.panelTxtParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTxtParent.Location = new System.Drawing.Point(0, 0);
            this.panelTxtParent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTxtParent.Name = "panelTxtParent";
            this.panelTxtParent.Size = new System.Drawing.Size(653, 423);
            this.panelTxtParent.TabIndex = 11;
            // 
            // tecVisualizationDescription
            // 
            this.tecVisualizationDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tecVisualizationDescription.IsReadOnly = false;
            this.tecVisualizationDescription.Location = new System.Drawing.Point(0, 0);
            this.tecVisualizationDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tecVisualizationDescription.Name = "tecVisualizationDescription";
            this.tecVisualizationDescription.Size = new System.Drawing.Size(653, 423);
            this.tecVisualizationDescription.TabIndex = 9;
            // 
            // panelStatistics
            // 
            this.panelStatistics.Controls.Add(this.buttonUpdateStatistics);
            this.panelStatistics.Controls.Add(this.listViewControlsAnalysis);
            this.panelStatistics.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelStatistics.Location = new System.Drawing.Point(653, 0);
            this.panelStatistics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.Size = new System.Drawing.Size(183, 423);
            this.panelStatistics.TabIndex = 10;
            // 
            // buttonUpdateStatistics
            // 
            this.buttonUpdateStatistics.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonUpdateStatistics.Location = new System.Drawing.Point(0, 404);
            this.buttonUpdateStatistics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUpdateStatistics.Name = "buttonUpdateStatistics";
            this.buttonUpdateStatistics.Size = new System.Drawing.Size(183, 19);
            this.buttonUpdateStatistics.TabIndex = 81;
            this.buttonUpdateStatistics.Text = "Recheck FormXml";
            this.buttonUpdateStatistics.UseVisualStyleBackColor = true;
            this.buttonUpdateStatistics.Click += new System.EventHandler(this.buttonUpdateStatistics_Click);
            // 
            // listViewControlsAnalysis
            // 
            this.listViewControlsAnalysis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewControlsAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewControlsAnalysis.FullRowSelect = true;
            this.listViewControlsAnalysis.HideSelection = false;
            this.listViewControlsAnalysis.Location = new System.Drawing.Point(0, 0);
            this.listViewControlsAnalysis.Name = "listViewControlsAnalysis";
            this.listViewControlsAnalysis.Size = new System.Drawing.Size(183, 423);
            this.listViewControlsAnalysis.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewControlsAnalysis.TabIndex = 80;
            this.listViewControlsAnalysis.UseCompatibleStateImageBehavior = false;
            this.listViewControlsAnalysis.View = System.Windows.Forms.View.Details;
            this.listViewControlsAnalysis.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewControlsAnalysis_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Control Name";
            this.columnHeader1.Width = 148;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "#";
            this.columnHeader2.Width = 73;
            // 
            // ddlNewGuid
            // 
            this.ddlNewGuid.FormattingEnabled = true;
            this.ddlNewGuid.Items.AddRange(new object[] {
            "tab",
            "section",
            "cell"});
            this.ddlNewGuid.Location = new System.Drawing.Point(180, 5);
            this.ddlNewGuid.Name = "ddlNewGuid";
            this.ddlNewGuid.Size = new System.Drawing.Size(93, 21);
            this.ddlNewGuid.TabIndex = 11;
            // 
            // btnGenerateNewGuid
            // 
            this.btnGenerateNewGuid.Location = new System.Drawing.Point(10, 2);
            this.btnGenerateNewGuid.Name = "btnGenerateNewGuid";
            this.btnGenerateNewGuid.Size = new System.Drawing.Size(164, 23);
            this.btnGenerateNewGuid.TabIndex = 12;
            this.btnGenerateNewGuid.Text = "New Guid For All=>";
            this.btnGenerateNewGuid.UseVisualStyleBackColor = true;
            this.btnGenerateNewGuid.Click += new System.EventHandler(this.btnGenerateNewGuid_Click);
            // 
            // FormXmlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 547);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTitle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormXmlEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormXml Editor";
            this.Load += new System.EventHandler(this.FormXmlEditor_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelTxtParent.ResumeLayout(false);
            this.panelStatistics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnlVisualEditor;
        private System.Windows.Forms.Button btnUpdatePublish;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonDeleteFormXml;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private ICSharpCode.TextEditor.TextEditorControl tecVisualizationDescription;
        private System.Windows.Forms.Panel panelStatistics;
        private System.Windows.Forms.Panel panelTxtParent;
        private System.Windows.Forms.ListView listViewControlsAnalysis;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonUpdateStatistics;
        private System.Windows.Forms.Button btnGenerateNewGuid;
        private System.Windows.Forms.ComboBox ddlNewGuid;
    }
}