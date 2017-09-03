namespace ITLec.FormXmlManager.Controls
{
    partial class TextControl
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
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxIgnoreSaving = new System.Windows.Forms.CheckBox();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(182, 4);
            this.txtText.Margin = new System.Windows.Forms.Padding(4);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(291, 26);
            this.txtText.TabIndex = 79;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel.Location = new System.Drawing.Point(4, 0);
            this.lblLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(141, 37);
            this.lblLabel.TabIndex = 80;
            this.lblLabel.Text = "Label";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtText, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIgnoreSaving, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelHelp, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 37);
            this.tableLayoutPanel1.TabIndex = 90;
            // 
            // checkBoxIgnoreSaving
            // 
            this.checkBoxIgnoreSaving.AutoSize = true;
            this.checkBoxIgnoreSaving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxIgnoreSaving.Location = new System.Drawing.Point(480, 3);
            this.checkBoxIgnoreSaving.Name = "checkBoxIgnoreSaving";
            this.checkBoxIgnoreSaving.Size = new System.Drawing.Size(116, 31);
            this.checkBoxIgnoreSaving.TabIndex = 81;
            this.checkBoxIgnoreSaving.Text = "Remove";
            this.checkBoxIgnoreSaving.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreSaving.Visible = false;
            // 
            // panelHelp
            // 
            this.panelHelp.BackgroundImage = global::ITLec.FormXmlManager.Properties.Resources.helpIcon;
            this.panelHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHelp.Location = new System.Drawing.Point(152, 3);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(20, 20);
            this.panelHelp.TabIndex = 82;
            this.panelHelp.Visible = false;
            this.panelHelp.Click += new System.EventHandler(this.panelHelp_Click);
            // 
            // TextControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TextControl";
            this.Size = new System.Drawing.Size(599, 37);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxIgnoreSaving;
        private System.Windows.Forms.Panel panelHelp;
    }
}
