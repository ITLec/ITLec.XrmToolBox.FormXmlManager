using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.FormXmlManager.AppCode
{
    public class SaveEventArgs : EventArgs
    {
        public Dictionary<string, ITLec.CRMFormXml.Property> AttributeCollection { get; set; }
    }
}
