using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITLec.FormXmlManager.Helpers;

namespace ITLec.FormXmlManager.Forms
{
    public partial class OverwriteConfirmationDialog : Form
    {
        private readonly List<FormXmlDefinition> formXmls;

        public OverwriteConfirmationDialog(List<FormXmlDefinition> formXmls)
        {
            InitializeComponent();

            this.formXmls = formXmls;
        }

        private void ErrorsListForm_Load(object sender, EventArgs e)
        {
            foreach (var formXml in formXmls.Where(c => c.Exists))
            {
                var item = new ListViewItem(formXml.Name) {Tag = formXml};
                item.Checked = true;

                lvFormXmls.Items.Add(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvFormXmls.Items)
            {
                ((FormXmlDefinition) item.Tag).Overwrite = item.Checked;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
