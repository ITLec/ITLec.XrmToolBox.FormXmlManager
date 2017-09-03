namespace ITLec.FormXmlManager.Controls
{
    partial class EnumControl
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
            this.cmbEnum = new System.Windows.Forms.ComboBox();
            this.lblEnum = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.checkBoxIgnoreSaving = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbEnum
            // 
            this.cmbEnum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEnum.FormattingEnabled = true;
            this.cmbEnum.Location = new System.Drawing.Point(181, 3);
            this.cmbEnum.Name = "cmbEnum";
            this.cmbEnum.Size = new System.Drawing.Size(293, 24);
            this.cmbEnum.TabIndex = 82;
            this.cmbEnum.SelectedIndexChanged += new System.EventHandler(this.cmbEnum_SelectedIndexChanged);
            // 
            // lblEnum
            // 
            this.lblEnum.AutoSize = true;
            this.lblEnum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnum.Location = new System.Drawing.Point(4, 0);
            this.lblEnum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnum.Name = "lblEnum";
            this.lblEnum.Size = new System.Drawing.Size(141, 37);
            this.lblEnum.TabIndex = 81;
            this.lblEnum.Text = "Enum Name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panelHelp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEnum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbEnum, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIgnoreSaving, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 37);
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
            // checkBoxIgnoreSaving
            // 
            this.checkBoxIgnoreSaving.AutoSize = true;
            this.checkBoxIgnoreSaving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxIgnoreSaving.Location = new System.Drawing.Point(480, 3);
            this.checkBoxIgnoreSaving.Name = "checkBoxIgnoreSaving";
            this.checkBoxIgnoreSaving.Size = new System.Drawing.Size(115, 31);
            this.checkBoxIgnoreSaving.TabIndex = 83;
            this.checkBoxIgnoreSaving.Text = "Remove";
            this.checkBoxIgnoreSaving.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreSaving.Visible = false;
            // 
            // EnumControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EnumControl";
            this.Size = new System.Drawing.Size(598, 37);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EnumControl_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEnum;
        private System.Windows.Forms.Label lblEnum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxIgnoreSaving;
        private System.Windows.Forms.Panel panelHelp;
    }
}
