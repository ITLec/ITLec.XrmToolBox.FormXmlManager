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
    public partial class FontControl : BaseFormXmlControl//UserControl//
    {
        

        public FontControl() 
        {
            
            InitializeComponent();

            FillControls();

            //if (!string.IsNullOrEmpty(base.InitValue))
            //{
            //    SetValue(base.InitValue);
            //}

            //InitValue = Value;
        }

        Dictionary<string, string> FontTypes = new Dictionary<string, string>();
        protected override void FillControls()
        {
            FontTypes = ITLec.CRMFormXmlGuy.AppCode.EnumHelper.GetCustomEnumItems("Font");
            ITLec.CRMFormXmlGuy.AppCode.Common.FillComboBox(comboBoxFontType, FontTypes);
        }

        protected override string GetValue()
        {
            string fontType = comboBoxFontType.Text;

            if(string.IsNullOrEmpty(fontType) )
            {
                return "";
            }

            string val = string.Format("{0}, {1}px", fontType, numericUpDownFontSize.Value.ToString());
            return val;
        }

       protected override void SetValue(string val)
        {

            if (!string.IsNullOrEmpty(val))
            {
                checkBoxIgnoreSaving.Visible = true;

                string[] strs = val.Split(',');

                if (strs.Length > 0)
                {
                    if (!FontTypes.ContainsKey(strs[0]))
                    {
                        FontTypes.Add(strs[0], strs[0]);
                        comboBoxFontType.DataSource = new BindingSource(FontTypes, null);
                    }

                    comboBoxFontType.Text = strs[0];


                    if (!string.IsNullOrEmpty(strs[1]))
                    {
                        string fontSizeStr = strs[1].Replace("px", "").Replace(" ", "");

                        decimal fontSize;
                        if (decimal.TryParse(fontSizeStr, out fontSize))
                        {
                            numericUpDownFontSize.Value = fontSize;
                            numericUpDownFontSize.ForeColor = Color.Black;
                        }
                    }
                }

            }
        }

        protected override bool GetIsIgnoreSave()
        {
            return checkBoxIgnoreSaving.Checked;
        }

        protected override void SetLabel(string label)
        {
            groupBoxFont.Text = label;
        }
        protected override string GetLabel()
        {
            return groupBoxFont.Text;
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownFontSize.ForeColor = Color.Black;

            checkBoxIgnoreSaving.Visible = true;
        }

        private void comboBoxFontType_SelectedIndexChanged(object sender, EventArgs e)
        {

            //   checkBoxIgnoreSaving.Visible = true;


            if (!string.IsNullOrEmpty(comboBoxFontType.SelectedValue.ToString()) &&
                comboBoxFontType.SelectedValue.ToString() != "[-1, ]")
            {
                checkBoxIgnoreSaving.Visible = true;
            }

        }
        


        protected override void SetDesc(string desc)
        {
            if (!string.IsNullOrEmpty(desc))
            {
                panelHelp.Visible = true;
            ControlToolTip.SetToolTip(lblFontType, desc);
            ControlToolTip.SetToolTip(lblFontSize, desc);
                ControlToolTip.SetToolTip(panelHelp, desc);

            }
        }


        private void panelHelp_Click(object sender, EventArgs e)
        {
            ControlToolTip.Show(this.Desc, panelHelp);
        }
    }
}
