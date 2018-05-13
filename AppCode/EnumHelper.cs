using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.CRMFormXml.AppCode
{
    public class EnumHelper
    {
        /*
        public static Dictionary<string, string> GetAllFormXmlTypes()
        {
            Dictionary<string, string> all = new Dictionary<string, string>();
            
            all.Add("Area", "Area");
            all.Add("Bar", "Bar");
            all.Add("BoxPlot", "BoxPlot");
            all.Add("Bubble", "Bubble");
            all.Add("Candlestick", "Candlestick");
            all.Add("Column", "Column");
            all.Add("Doughnut", "Doughnut");
            all.Add("ErrorBar", "ErrorBar");
            all.Add("FastLine", "FastLine");
            all.Add("FastPoint", "FastPoint");
            all.Add("Funnel", "Funnel");
            all.Add("Kagi", "Kagi");
            all.Add("Line", "Line");
            all.Add("Pie", "Pie");
            all.Add("Point", "Point");
            all.Add("PointAndFigure", "PointAndFigure");
            all.Add("Polar", "Polar");
            all.Add("Pyramid", "Pyramid");
            all.Add("Radar", "Radar");
            all.Add("Range", "Range");
            all.Add("RangeBar", "RangeBar");
            all.Add("RangeColumn", "RangeColumn");
            all.Add("Renko", "Renko");
            all.Add("Spline", "Spline");
            all.Add("SplineArea", "SplineArea");
            all.Add("SplineRange", "SplineRange");
            all.Add("StackedArea", "StackedArea");
            all.Add("StackedArea100", "StackedArea100");
            all.Add("StackedBar", "StackedBar");
            all.Add("StackedBar100", "StackedBar100");
            all.Add("StackedColumn", "StackedColumn");
            all.Add("StackedColumn100", "StackedColumn100");
            all.Add("StepLine", "StepLine");
            all.Add("Stock", "Stock");
            all.Add("ThreeLineBreak", "ThreeLineBreak");

            return all;
        }

        */

      /*  public static Dictionary<string, string> GetAllFontTypes()
        {
            Dictionary<string, string> all = new Dictionary<string, string>();
            all.Add("Arial", "Arial");
            all.Add("Arial Black", "Arial Black");
            all.Add("Comic Sans MS", "Comic Sans MS");
            all.Add("Courier New", "Courier New");
            all.Add("Georgia", "Georgia");
            all.Add("Impact", "Impact");
            all.Add("Lucida Console", "Lucida Console");
            all.Add("Lucida Sans Unicode", "Lucida Sans Unicode");
            all.Add("Palatino Linotype", "Palatino Linotype");
            all.Add("Tahoma", "Tahoma");
            all.Add("Times New Roman", "Times New Roman");
            all.Add("Trebuchet", "Trebuchet");
            all.Add("Verdana", "Verdana");
            all.Add("Symbol", "Symbol");
            all.Add("Webdings", "Webdings");
            all.Add("Wingdings", "Wingdings");
            all.Add("MS Sans Serif", "MS Sans Serif");
            all.Add("MS Serif", "MS Serif");
            all.Add("{0}", "{0}");

            return all;
        }*/
        public static Dictionary<string, string> GetCustomEnumItems(string enumType)
        {
            Dictionary<string, string> all = new Dictionary<string, string>();

            all.Add("-1", "");

            var _formXml = ITLec.CRMFormXml.AppCode.Common.FormXmlStructure;

            var customEnum = _formXml.CustomEnums.Where(e => e.Name.ToLower() == enumType.ToLower()).FirstOrDefault();

            if (customEnum != null)
            {
                foreach (var item in customEnum.EnumItems)
                {
                    all.Add(item.Name, item.Name);
                }
            }
            return all;
        }
        /*
        public static Dictionary<string, string> GetAllGradientStyleTypes()
        {
            Dictionary<string, string> all = new Dictionary<string, string>();
            all.Add("Center", "Center");
            all.Add("DiagonalLeft", "DiagonalLeft");
            all.Add("DiagonalRight", "DiagonalRight");
            all.Add("HorizontalCenter", "HorizontalCenter");
            all.Add("LeftRight", "LeftRight");
            all.Add("None", "None");
            all.Add("TopBottom", "TopBottom");
            all.Add("VerticalCenter", "VerticalCenter");
            return all;
        }*/

    }
}
