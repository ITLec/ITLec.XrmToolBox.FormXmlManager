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
    public partial class ErrorsListForm : Form
    {
        private readonly List<FormXmlDefinition> formXmls;

        public ErrorsListForm(List<FormXmlDefinition> formXmls)
        {
            InitializeComponent();

            this.formXmls = formXmls;
        }

        private void ErrorsListForm_Load(object sender, EventArgs e)
        {
            foreach (var formXml in formXmls)
            {
                foreach (var error in formXml.Errors)
                {
                    var item = new ListViewItem(formXml.Name);
                    item.SubItems.Add(error);

                    listView1.Items.Add(item);
                }
            }
        }
    }
}
