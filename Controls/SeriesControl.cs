using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using ITLecChartGuy.AdvancedChartEditor.AppCode;

namespace ITLecChartGuy.AdvancedChartEditor.Controls
{
    public partial class SeriesControl  : BaseMainChartUserControl, IChartSavable //:UserControl//
    {

      /*  #region Delegates

        public delegate void SaveEventHandler(object sender, SaveEventArgs e);

        #endregion
        #region Event Handlers

        public event SaveEventHandler Saved;

        #endregion*/
        private readonly Dictionary<string, ITLec.CRMChartGuy.Property> collec;

        public SeriesControl()
        {
            InitializeComponent();
            collec = new Dictionary<string, ITLec.CRMChartGuy.Property>();
        }

        public SeriesControl(Dictionary<string, ITLec.CRMChartGuy.Property> collection)
            : this()
        {
            if (collection != null)
                collec = collection;

            FillControls();
        }

        private void FillControls()
        {

            var _chart = ITLec.CRMChartGuy.AppCode.Common.ChartStructure;

            var sections = _chart.Sections.Where(e => e.Name == "Series").FirstOrDefault();

            foreach (var property in sections.Properties)
            {
                AddDictionaryKeyControl(property, collec);
            }

            foreach(var item in collec)
            {
              if(  sections.Properties.Where(e => e.Name == item.Key).Count() == 0)
                {
                    
                    AddDictionaryKeyControl(item.Value);
                }
            }

            int x = 0;
            foreach(var item in DictionaryKeyControl.Values)
            {
                item.Location = new Point(0, x);
                x = x + 50;
                panelMain.Height = panelMain.Height + 50;
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
