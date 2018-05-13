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
    public partial class ColorControl :BaseFormXmlControl// UserControl//
    {

        public ColorControl()
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
        private void lblColor_Click(object sender, EventArgs e)
        {
            pickColor();
        }

        private void pickColor()
        {
            DialogResult result = colorDialogSelector.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                panelColor.BackColor = colorDialogSelector.Color;

                textBoxColor.Text = string.Format("{0}, {1}, {2}", panelColor.BackColor.R, panelColor.BackColor.G, panelColor.BackColor.B);
              
            }
        }

        protected override string GetValue()
        {
            string str = textBoxColor.Text;// string.Format("{0}, {1}, {2}", panelColor.BackColor.R, panelColor.BackColor.G, panelColor.BackColor.B);
            return str;
        }

        protected override void SetValue(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
            textBoxColor.Text = val;
            checkBoxIgnoreSaving.Visible = true;
                string[] strs = val.Split(',');

                Color color = ITLec.CRMFormXml.AppCode.Common.ConvertStringToColor(val).Value;
                panelColor.BackColor = color;
            }
        }


        protected override void SetLabel(string label)
        {
            lblColorLLabel.Text = label;
        }
        protected override string GetLabel()
        {
            return lblColorLLabel.Text;
        }

        protected override bool  GetIsIgnoreSave()
        {
            return checkBoxIgnoreSaving.Checked;
        }

        private void panelColor_Click(object sender, EventArgs e)
        {

            pickColor();
        }

        private void textBoxColor_TextChanged(object sender, EventArgs e)
        {
            checkBoxIgnoreSaving.Visible = true;
            try
            {
                Color? color = ITLec.CRMFormXml.AppCode.Common.ConvertStringToColor(textBoxColor.Text);
                if (color != null)
                {
                    panelColor.BackColor = color.Value;
                }
            }
            catch(Exception exc)
            {
                //panelColor.
            }
        }

        private void lblClickToSelectColor_Click(object sender, EventArgs e)
        {

            pickColor();
        }
        
        protected override void SetDesc(string desc)
        {
            if (!string.IsNullOrEmpty(desc))
            {
                panelHelp.Visible = true;
                ControlToolTip.SetToolTip(lblColorLLabel, desc);
                ControlToolTip.SetToolTip(panelHelp, desc);

            }
        }


        private void panelHelp_Click(object sender, EventArgs e)
        {
            ControlToolTip.Show(this.Desc, panelHelp);
        }
    }
}
