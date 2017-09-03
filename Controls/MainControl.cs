using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITLecChartGuy.AdvancedChartManager.AppCode;
using ITLec.CRMChartGuy.AppCode;

namespace ITLecChartGuy.AdvancedChartManager.Controls
{
    public partial class MainControl :   BaseMainChartUserControl, IChartSavable
    {
        private readonly Dictionary<string, string> collec;
        private string nodeName;

        public MainControl()
        {
            InitializeComponent();
            collec = new Dictionary<string, string>();
        }

        public MainControl(Dictionary<string, string> collection)
            : this()
        {
            if (collection != null)
                collec = collection;

            FillControls();
        }

        public MainControl(string nodeName, Dictionary<string, string> collec)
            : this()
        {
            this.nodeName = nodeName;
            this.collec = collec;

            FillControls();
        }

        private void FillControls()
        {

            var _chart = ITLec.CRMChartGuy.AppCode.Common.ChartStructure;

            var section = _chart.Sections.Where(e => e.Name == nodeName).FirstOrDefault();

            if (section != null && section.Properties.Count > 0)
            {
                foreach (var property in section.Properties)
                {
                    AddDictionaryKeyControl(property, collec);
                }

                foreach (var item in collec)
                {
                    if (section.Properties.Where(e => e.Name == item.Key).Count() == 0)
                    {
                        AddDictionaryKeyControl("Text", item.Key, item.Value);
                    }
                }

            }else
            {
                foreach (var item in collec)
                {
                        AddDictionaryKeyControl(Common.DetectChartElementType(item.Key, item.Value), item.Key, item.Value);
                }
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

            Dictionary<string, string> collection = new Dictionary<string, string>();

            foreach (var dic in DictionaryKeyControl)
            {
                if (collec.Keys.Contains(dic.Key) ||
                    (!string.IsNullOrEmpty(dic.Value.Value) &&

                    dic.Value.Value != dic.Value.InitValue))
                {
                    collection.Add(dic.Key, dic.Value.Value);
                }
            }

            SendSaveMessage(collection);
            return true;
        }


        #region Send Events

        private void SendSaveMessage(Dictionary<string, string> collection)
        {
            SaveEventArgs sea = new SaveEventArgs { AttributeCollection = collection };
            OnSaving(this, sea);
        }

        #endregion
    }
}
