using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITLec.CRMFormXmlGuy.AppCode;
using ITLec.FormXmlManager.AppCode;
using ITLec.CRMFormXmlGuy;
using ITLec.FormXmlManager.Forms;

namespace ITLec.FormXmlManager.Controls
{
    public partial class MainFormXmlSectionControl : BaseMainFormXmlUserControl, IFormXmlSavable
    {
        private readonly Dictionary<string, Property> collec;

        public MainFormXmlSectionControl()
        {
            InitializeComponent();
            collec = new Dictionary<string, Property>();
        }

        public MainFormXmlSectionControl(Dictionary<string, Property> collection)
            : this()
        {
            if (collection != null)
                collec = collection;

            FillControls();
        }

        public MainFormXmlSectionControl(string nodeName, Dictionary<string, Property> collec)
            : this()
        {
            this.NodeName = nodeName;
            this.collec = collec;

            FillControls();
        }

        private void FillControls()
        {

            var _formXml = ITLec.CRMFormXmlGuy.AppCode.Common.FormXmlStructure;
            Section section = null;
            if (NodeName == "Series.Series.CustomProperties")
            {
                section = _formXml.Sections.Where(e => e.Name == "Series.Series.CustomProperties."+FormXmlEditorHelper.FormXmlType).FirstOrDefault();
            }
            else
            {
                 section = _formXml.Sections.Where(e => e.Name == NodeName).FirstOrDefault();
            }


            if (section != null && section.Properties.Count > 0)
            {
                foreach (var property in section.Properties)
                {
                    AddDictionaryKeyControl(property, collec);
                }
            }

            foreach (var item in collec)
            {
                item.Value.Type = Common.DetectFormXmlElementType(item.Key, item.Value.Value);
                AddDictionaryKeyControl( item.Value);
            }

            int x = 0;
            foreach (var item in DictionaryKeyControl.Values)
            {
                item.Location = new Point(0, x);
                x = x + 50;
                panelMain.Height = panelMain.Height + 50;
                item.Dock = DockStyle.Top;
                panelMain.Controls.Add(item);
            }

        }



        public bool Save()
        {

            Dictionary<string, ITLec.CRMFormXmlGuy.Property> collection = new Dictionary<string, ITLec.CRMFormXmlGuy.Property>();

            foreach (var dic in DictionaryKeyControl)
            {
                if (
                    
                  (  collec.Keys.Contains(dic.Key) ||
                    (!string.IsNullOrEmpty(dic.Value.Value) )) &&

                   ! dic.Value.IsIgnoreSave
                    )
                {
                    collection.Add(dic.Key, dic.Value.CurrentProperty);
                }
            }

            SendSaveMessage(collection);
            return true;
        }


        #region Send Events

        private void SendSaveMessage(Dictionary<string, ITLec.CRMFormXmlGuy.Property> collection)
        {
            SaveEventArgs sea = new SaveEventArgs { AttributeCollection = collection };
            OnSaving(this, sea);
        }

        #endregion
    }
}
