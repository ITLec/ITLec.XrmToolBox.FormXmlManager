namespace ITLec.FormXmlManager.Controls
{
    partial class ColorControl
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
            this.lblColorLLabel = new System.Windows.Forms.Label();
            this.colorDialogSelector = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.panelColor = new System.Windows.Forms.Panel();
            this.lblClickToSelectColor = new System.Windows.Forms.Label();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.checkBoxIgnoreSaving = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblColorLLabel
            // 
            this.lblColorLLabel.AutoSize = true;
            this.lblColorLLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColorLLabel.Location = new System.Drawing.Point(3, 0);
            this.lblColorLLabel.Name = "lblColorLLabel";
            this.lblColorLLabel.Size = new System.Drawing.Size(143, 44);
            this.lblColorLLabel.TabIndex = 1;
            this.lblColorLLabel.Text = "Color";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panelHelp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblColorLLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelColor, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxColor, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIgnoreSaving, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(596, 44);
            this.tableLayoutPanel1.TabIndex = 90;
            // 
            // panelHelp
            // 
            this.panelHelp.BackgroundImage = global::ITLec.FormXmlManager.Properties.Resources.helpIcon;
            this.panelHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHelp.Location = new System.Drawing.Point(152, 3);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(20, 20);
            this.panelHelp.TabIndex = 84;
            this.panelHelp.Visible = false;
            this.panelHelp.Click += new System.EventHandler(this.panelHelp_Click);
            // 
            // panelColor
            // 
            this.panelColor.Controls.Add(this.lblClickToSelectColor);
            this.panelColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColor.Location = new System.Drawing.Point(181, 3);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(143, 38);
            this.panelColor.TabIndex = 3;
            this.panelColor.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // lblClickToSelectColor
            // 
            this.lblClickToSelectColor.AutoSize = true;
            this.lblClickToSelectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClickToSelectColor.Location = new System.Drawing.Point(0, 0);
            this.lblClickToSelectColor.Name = "lblClickToSelectColor";
            this.lblClickToSelectColor.Size = new System.Drawing.Size(138, 17);
            this.lblClickToSelectColor.TabIndex = 0;
            this.lblClickToSelectColor.Text = "Click To Select Color";
            this.lblClickToSelectColor.Click += new System.EventHandler(this.lblClickToSelectColor_Click);
            // 
            // textBoxColor
            // 
            this.textBoxColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxColor.Location = new System.Drawing.Point(330, 3);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(143, 22);
            this.textBoxColor.TabIndex = 4;
            this.textBoxColor.TextChanged += new System.EventHandler(this.textBoxColor_TextChanged);
            // 
            // checkBoxIgnoreSaving
            // 
            this.checkBoxIgnoreSaving.AutoSize = true;
            this.checkBoxIgnoreSaving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxIgnoreSaving.Location = new System.Drawing.Point(479, 3);
            this.checkBoxIgnoreSaving.Name = "checkBoxIgnoreSaving";
            this.checkBoxIgnoreSaving.Size = new System.Drawing.Size(114, 38);
            this.checkBoxIgnoreSaving.TabIndex = 5;
            this.checkBoxIgnoreSaving.Text = "Remove";
            this.checkBoxIgnoreSaving.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreSaving.Visible = false;
            // 
            // ColorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorControl";
            this.Size = new System.Drawing.Size(596, 44);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelColor.ResumeLayout(false);
            this.panelColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblColorLLabel;
        private System.Windows.Forms.ColorDialog colorDialogSelector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.Label lblClickToSelectColor;
        private System.Windows.Forms.CheckBox checkBoxIgnoreSaving;
        private System.Windows.Forms.Panel panelHelp;
    }
}
