using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsCrmTools.ChartManager.Controls
{
    public interface IBaseChartControl
    {
        string GetValue();

        void SetValue(string val);

        void SetLabel(string label);
    }
}
