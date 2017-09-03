namespace ITLec.FormXmlManager.Controls
{
    partial class NumberControl
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
            this.lblNumber = new System.Windows.Forms.Label();
            this.numericUpDownNumber = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.checkBoxIgnoreSaving = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumber.Location = new System.Drawing.Point(3, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(144, 45);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Number";
            // 
            // numericUpDownNumber
            // 
            this.numericUpDownNumber.DecimalPlaces = 1;
            this.numericUpDownNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownNumber.ForeColor = System.Drawing.SystemColors.Window;
            this.numericUpDownNumber.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownNumber.Location = new System.Drawing.Point(183, 3);
            this.numericUpDownNumber.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownNumber.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numericUpDownNumber.Name = "numericUpDownNumber";
            this.numericUpDownNumber.Size = new System.Drawing.Size(294, 22);
            this.numericUpDownNumber.TabIndex = 1;
            this.numericUpDownNumber.ValueChanged += new System.EventHandler(this.numericUpDownNumber_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panelHelp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNumber, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownNumber, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIgnoreSaving, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(601, 45);
            this.tableLayoutPanel1.TabIndex = 88;
            // 
            // panelHelp
            // 
            this.panelHelp.BackgroundImage = global::ITLec.FormXmlManager.Properties.Resources.helpIcon;
            this.panelHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHelp.Location = new System.Drawing.Point(153, 3);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(20, 20);
            this.panelHelp.TabIndex = 83;
            this.panelHelp.Visible = false;
            this.panelHelp.Click += new System.EventHandler(this.panelHelp_Click);
            // 
            // checkBoxIgnoreSaving
            // 
            this.checkBoxIgnoreSaving.AutoSize = true;
            this.checkBoxIgnoreSaving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxIgnoreSaving.Location = new System.Drawing.Point(483, 3);
            this.checkBoxIgnoreSaving.Name = "checkBoxIgnoreSaving";
            this.checkBoxIgnoreSaving.Size = new System.Drawing.Size(115, 39);
            this.checkBoxIgnoreSaving.TabIndex = 2;
            this.checkBoxIgnoreSaving.Text = "Remove";
            this.checkBoxIgnoreSaving.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreSaving.Visible = false;
            // 
            // NumberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NumberControl";
            this.Size = new System.Drawing.Size(601, 45);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownNumber;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxIgnoreSaving;
        private System.Windows.Forms.Panel panelHelp;
    }
}
