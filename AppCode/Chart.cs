using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.CRMFormXml
{

    public class FormXml
    {

        public List<Property> FormXmlProperties = new List<Property>();

        public List<Section> Sections = new List<Section>();

        public List<CustomEnum> CustomEnums = new List<CustomEnum>();


        public List<CustomProperties> CustomPropertiesSet = new List<CustomProperties>();
    }

    public class Section
    {
        public string Name
        {
            get;
            set;
        }
        public List<Property> Properties = new List<Property>();


        public List<SubSection> SubSections = new List<SubSection>();
    }


    public class SubSection
    {
        public string Name
        {
            get;
            set;
        }
    }
        public class CustomProperties
    {
        public string FormXmlType
        {
            get;
            set;
        }
        public List<Property> Properties = new List<Property>();
    }

    public class Property : PropertyHeader
    {

        public List<CustomProperty> CustomProperties = new List<CustomProperty>();
    }
    public class CustomProperty 
    {

        public string PropertyValue
        {
            get;
            set;
        }

        public List<Property> Properties = new List<Property>();
    }

    public class PropertyHeader
    {
        public string Name
        {
            get;
            set;
        }
        public string DisplayName
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string Desc
        {
            get;
            set;
        }
        public string Value
        {
            get;
            set;
        }
        //public string PropertyTypeValue
        //{
        //    get;
        //    set;
        //}

        //public PropertyType PropertyType
        //{
        //    get;
        //    set;
        //}
        public string DefaultValue
        {
            get;
            set;
        }

    }


    public class CustomEnum
    {
        public string Name { get; set; }
        public List<EnumItem> EnumItems = new List<EnumItem>();
    }

    public class EnumItem
    {
        public string Name
        {
            get;
            set;
        }
    }

    public class PropertyType
    {
        public  const string   TEXT = "text";
        public const string NUMBER = "number";
        //public const string Decimal = "decimal";
        public  const string COLOR = "color";
        public  const string FONT = "font";
        public const string ENUM = "enum";
    }

}
