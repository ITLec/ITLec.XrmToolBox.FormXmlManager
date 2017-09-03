using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLec.FormXmlManager.Controls
{
    public abstract class BaseFormXmlControl : UserControl
    {

       public  BaseFormXmlControl()
        {
            //  IsNull = true;
            ControlToolTip = new ToolTip();

            // Set up the delays for the ToolTip.
            ControlToolTip.AutoPopDelay = 5000;
            ControlToolTip.InitialDelay = 1000;
            ControlToolTip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            ControlToolTip.ShowAlways = true;

        }
        public string InitValue = "";

        /*
        public bool IsNull
        {
            get
            {
                bool isNull = false;

                if(Value != InitValue)
                {
                    isNull = true;
                }
                return isNull;
            }
        }*/


            public ToolTip ControlToolTip
        {
            get;
            set;
        }

        public string Value
        {
            get
            {
                return GetValue();
            }
            set
            {
                SetValue(value);
            }
        }

        public string Key;

        public string Label
        {
            get
            {
                return GetLabel();
            }
            set
            {
                SetLabel(value);
            }
        }

        private string desc;
        public string Desc
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
                SetDesc(value);
            }
        }

        public bool IsIgnoreSave
        {

            get
            {
                return GetIsIgnoreSave();
            }
            //set
            //{
            //    SetLabel(value);
            //}
        }

        public bool? IsValueChanged { get;  set; }

        protected abstract string GetValue();
        
        protected abstract void SetValue(string val);

        protected abstract void SetLabel(string label);
        protected abstract string GetLabel();
        protected abstract void FillControls();
        protected abstract bool GetIsIgnoreSave();


        protected abstract void SetDesc(string desc);
        
        public ITLec.CRMFormXmlGuy.Property CurrentProperty
        {
            get
            {
               var retVal =  new ITLec.CRMFormXmlGuy.Property() {/*DefaultValue = this.InitValue,*/ Desc=this.Desc, DisplayName=this.Label, Name= this.Key, Value = this.Value};

                return retVal;
            }
        }
    }
}
