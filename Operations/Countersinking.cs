using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations
{
    internal class Countersinking : HoleProcessing
    {
        public override string Name => "Зенковка";
        protected override List<ToolType> GetTools()
        {
            var toolsData = Configuration.Instance.ProcessingData.ToolsData;
            return new() { toolsData.CountersinkTool };
        }
    }
}
