using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLec.FormXmlManager.Controls
{
    public partial class TextControl :BaseFormXmlControl// UserControl// 
    {
        public TextControl()
        {
            InitializeComponent();

            FillControls();
            //if (!string.IsNullOrEmpty(base.InitValue))
            //{
            //    SetValue(base.InitValue);
            //}

            //InitValue = Value;
        }

        protected override void FillControls()
        {
        }


        protected override string GetValue()
        {
            string str = txtText.Text;
            return str;
        }

        protected override void SetValue(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                checkBoxIgnoreSaving.Visible = true;
                txtText.Text = val;
            }
        }


        protected override void SetLabel(string label)
        {
            lblLabel.Text = label;
        }
        protected override string GetLabel()
        {
            return lblLabel.Text;
        }

        protected override bool GetIsIgnoreSave()
        {
            return checkBoxIgnoreSaving.Checked;
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            checkBoxIgnoreSaving.Visible = true;
        }


        protected override void SetDesc(string desc)
        {
            if (!string.IsNullOrEmpty(desc))
            {
                panelHelp.Visible = true;
                ControlToolTip.SetToolTip(lblLabel, desc);
                ControlToolTip.SetToolTip(panelHelp, desc);

            }
        }

        private void panelHelp_Click(object sender, EventArgs e)
        {
            ControlToolTip.Show(this.Desc, panelHelp);
        }
    }
}
