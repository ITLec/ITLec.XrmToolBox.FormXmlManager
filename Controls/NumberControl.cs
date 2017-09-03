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
    public partial class NumberControl : BaseFormXmlControl//  UserControl//
    {
        //{Min=1,Max=20,DecimalPlaces=1,Increment=.1}
        public NumberControl(string args)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(args))
            {
                string[] arrArg = args.ToLower().Replace("{", "").Replace("}", "").Split(',');

                if (arrArg.Length > 0)
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();

                    foreach (string str in arrArg)
                    {
                        if (str.Contains("="))
                        {
                            string[] strs = str.Split('=');

                            if (!string.IsNullOrEmpty(strs[0]) && !string.IsNullOrEmpty(strs[1]))
                            {
                                dic.Add(strs[0], strs[1]);
                            }
                        }
                    }

                    if (dic.ContainsKey("min"))
                    {
                        int minimun = 0;
                        if (int.TryParse(dic["min"], out minimun))
                        {
                            numericUpDownNumber.Minimum = minimun;
                        }
                    }

                    if (dic.ContainsKey("max"))
                    {
                        int max = 0;
                        if (int.TryParse(dic["max"], out max))
                        {
                            numericUpDownNumber.Maximum = max;
                        }
                    }

                    if (dic.ContainsKey("decimalplaces"))
                    {
                        int decimalplaces = 0;
                        if (int.TryParse(dic["decimalplaces"], out decimalplaces))
                        {
                            numericUpDownNumber.DecimalPlaces = decimalplaces;
                        }
                    }

                    if (dic.ContainsKey("increment"))
                    {
                        int increment = 0;
                        if (int.TryParse(dic["increment"], out increment))
                        {
                            numericUpDownNumber.Increment = increment;
                        }
                    }
                }
            }
        }

        protected override void FillControls()
        {

        }

        protected override string GetLabel()
        {
            return lblNumber.Text;
        }

        protected override string GetValue()
        {
           return numericUpDownNumber.Value.ToString();
        }

        protected override void SetLabel(string label)
        {
            lblNumber.Text = label;
        }

        protected override void SetValue(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                checkBoxIgnoreSaving.Visible = true;
                decimal _val = 0;
                if (decimal.TryParse(val, out _val))
                {
            numericUpDownNumber.ForeColor = Color.Black;
                numericUpDownNumber.Value = _val;
                }

            }
        }

        protected override bool GetIsIgnoreSave()
        {
            return checkBoxIgnoreSaving.Checked ||  (numericUpDownNumber.ForeColor != Color.Black);
        }
        private void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownNumber.ForeColor = Color.Black;
            checkBoxIgnoreSaving.Visible = true;
        }

        protected override void SetDesc(string desc)
        {
            if (!string.IsNullOrEmpty(desc))
            {
                panelHelp.Visible = true;
                ControlToolTip.SetToolTip(lblNumber, desc);
                ControlToolTip.SetToolTip(panelHelp, desc);

            }
        }


        private void panelHelp_Click(object sender, EventArgs e)
        {
            ControlToolTip.Show(this.Desc, panelHelp);
        }
    }
}
