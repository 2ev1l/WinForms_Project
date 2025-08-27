using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Processing
{
    internal readonly struct ToolModel
    {
        public string UIName { get; }
        public ToolModel(string UIName)
        {
            this.UIName = UIName;
        }
    }
}
