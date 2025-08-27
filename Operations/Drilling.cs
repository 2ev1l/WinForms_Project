using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations
{
    internal class Drilling : HoleProcessing
    {
        public override string Name => "Сверление";
        protected override List<ToolType> GetTools()
        {
            var toolsData = Configuration.Instance.ProcessingData.ToolsData;
            return new() { toolsData.DrillTool };
        }
    }
}
