using ITLec.CRMFormXmlGuy;
using ITLec.FormXmlManager.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLec.FormXmlManager.Controls
{
public  class BaseMainFormXmlUserControl :  UserControl
    {

        public string NodeName;


        public  event Action<object, SaveEventArgs> Saving;

        protected virtual void OnSaving(object sender, SaveEventArgs arg)
        {
            Saving?.Invoke(sender, arg);
        }

        public Dictionary<string, BaseFormXmlControl> DictionaryKeyControl = new Dictionary<string, BaseFormXmlControl>();

        
        public void AddDictionaryKeyControl(BaseFormXmlControl obj, Property property)
        {

            obj.Key = property.Name;
            obj.Value = property.Value;
       //     obj.InitValue = property.DefaultValue;

            obj.Label = (!string.IsNullOrEmpty( property.DisplayName) ) ? property.DisplayName : property.Name;
            
            obj.Desc = property.Desc;

            DictionaryKeyControl.Add(property.Name, obj);

        }
       /* public void AddDictionaryKeyControl(BaseFormXmlControl obj, string key, string val, string label = "")
        {

            obj.Key = key;
            obj.Value = val;
            obj.InitValue = obj.Value;

            obj.Label = (label != "") ? label : key;

            DictionaryKeyControl.Add(key, obj);

        }*/

     /*   public void AddDictionaryKeyControl(Property property, Dictionary<string, string> collec)
        {
            var val = collec.ContainsKey(property.Name) ? collec[property.Name] : "";

            AddDictionaryKeyControl(property);
        }*/

        public void AddDictionaryKeyControl(Property property, Dictionary<string, Property> collec)
        {
    //        var val = property.DefaultValue;

            if (collec.ContainsKey(property.Name)
                    && collec[property.Name] != null)
            {
                if (!string.IsNullOrEmpty(collec[property.Name].Value))
                {
                    property.Value = collec[property.Name].Value;
                }


                //if (!string.IsNullOrEmpty(collec[property.Name].DefaultValue))
                //{
                //    property.DefaultValue = collec[property.Name].DefaultValue;
                //}

            }
            
            //20170625    AddDictionaryKeyControl(property.Type, property.Name, val, label);

            AddDictionaryKeyControl(property);
        }
        public void AddDictionaryKeyControl(Property property)
        {

            if (!DictionaryKeyControl.ContainsKey(property.Name))
            {

                BaseFormXmlControl obj = null;
                string[] strs = property.Type.ToLower().Split(':');
                switch (strs[0])
                {
                    case PropertyType.TEXT:
                        obj = new TextControl();
                        break;
                    case PropertyType.NUMBER:
                        string param = (strs.Length ==1) ? "" : strs[1];
                        obj = new NumberControl(param);
                        break;
                    case PropertyType.COLOR:
                        obj = new ColorControl();
                        break;
                    case PropertyType.FONT:
                        obj = new FontControl();
                        break;
                    case PropertyType.ENUM:
                        obj = new EnumControl(NodeName + ":" + strs[1]);
                        break;

                    default:
                        obj = new TextControl();
                        break;
                }

                AddDictionaryKeyControl(obj, property);
                Property p = new Property();
            }

        }
     /*20170625   public void AddDictionaryKeyControl(string type, string key, string val, string label = "")
        {

            if (!DictionaryKeyControl.ContainsKey(key))
            {

                BaseFormXmlControl obj = null;
                string[] strs = type.ToLower().Split(':');
                switch (strs[0])
                {
                    case PropertyType.TEXT:
                        obj = new TextControl();
                        break;
                    case PropertyType.NUMBER:
                        obj = new NumberControl();
                        break;
                    case PropertyType.COLOR:
                        obj = new ColorControl();
                        break;
                    case PropertyType.FONT:
                        obj = new FontControl();
                        break;
                    case PropertyType.ENUM:
                        obj = new EnumControl(NodeName + ":" + strs[1]);
                        break;

                    default:
                        obj = new TextControl();
                        break;
                }

                AddDictionaryKeyControl(obj, key, val, label);
                Property p = new Property();
            }

        }*/

    }
}
