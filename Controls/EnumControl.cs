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
    public partial class EnumControl : BaseFormXmlControl//UserControl//
    {
        string currentNodeName;
        string _enumType;
        public EnumControl(string enumType)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(enumType))
            {
                string[] strs = enumType.Split(':');
                if (strs.Count() > 0)
                {
                    currentNodeName = strs[0];
                    _enumType = strs[1];
                }
            }

            FillControls();
        }

        Dictionary<string, string> EnumItems = new Dictionary<string, string>();
        protected override void FillControls()
        {
            EnumItems =
                                 ITLec.CRMFormXml.AppCode.EnumHelper.GetCustomEnumItems(_enumType);
            ITLec.CRMFormXml.AppCode.Common.FillComboBox(cmbEnum, EnumItems);

            SetCustomProperties();
        }

        private void SetCustomProperties()
        {
            //   throw new NotImplementedException();


            var _formXml = ITLec.CRMFormXml.AppCode.Common.FormXmlStructure;

            var section = _formXml.Sections.Where(e => e.Name.ToLower() == currentNodeName.ToLower()).FirstOrDefault();

            if (section != null && section.Properties.Count > 0)
            {
                var property = section.Properties.Where(e => e.Name.ToLower() == _enumType.ToLower()).FirstOrDefault();

                if (property != null && property.CustomProperties.Count > 0)
                {
                    var customProperty = property.CustomProperties.Where(e => e.PropertyValue.ToLower() == cmbEnum.Text.ToLower()).FirstOrDefault();

                    if (customProperty != null && customProperty.Properties.Count > 0)
                    {
                        var dd = customProperty.Properties;
                        //TODO: Display Controls
                    }
                }
            }
        }

        protected override string GetLabel()
        {

            string str = lblEnum.Text;
            return str;
        }

        protected override string GetValue()
        {
            string str = cmbEnum.Text;
            return str;
        }

        protected override void SetLabel(string label)
        {
            lblEnum.Text = label;
        }

        protected override void SetValue(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                checkBoxIgnoreSaving.Visible = true;
                if (!EnumItems.ContainsKey(val))
                {
                    EnumItems.Add(val, val);
                    ITLec.CRMFormXml.AppCode.Common.FillComboBox(cmbEnum, EnumItems);
                }

                cmbEnum.Text = val;

                // cmbEnum.high
                //    cmbEnum.BeginInvoke(new Action(() => cmbEnum.SelectionLength = 0));
                //     cmbEnum.BeginInvoke(new Action(() => { cmbEnum.Select(0, 0); }));
                //lblEnum.Focus();
            }
        }


        protected override bool GetIsIgnoreSave()
        {
            return checkBoxIgnoreSaving.Checked;
        }

        private void cmbEnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbEnum.SelectedValue.ToString()) && 
                cmbEnum.SelectedValue.ToString() != "[-1, ]")
            {
                checkBoxIgnoreSaving.Visible = true;
            }
            SetCustomProperties();
        }

        private void EnumControl_Paint(object sender, PaintEventArgs e)
        {

            cmbEnum.SelectionLength = 0;
        }

        protected override void SetDesc(string desc)
        {
            if (!string.IsNullOrEmpty(desc))
            {
                panelHelp.Visible = true;
                ControlToolTip.SetToolTip(lblEnum, desc);
                ControlToolTip.SetToolTip(panelHelp, desc);

            }
        }


        private void panelHelp_Click(object sender, EventArgs e)
        {
            ControlToolTip.Show(this.Desc, panelHelp);
        }
    }
}
