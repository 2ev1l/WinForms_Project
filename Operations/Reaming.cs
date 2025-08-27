using ProcessingTimeCalc.Operations.Parameters;
using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations
{
    internal class Reaming : HoleProcessing
    {
        public override string Name => "Развертка";
        protected override List<ToolType> GetTools()
        {
            var toolsData = Configuration.Instance.ProcessingData.ToolsData;
            return new() { toolsData.ReamerTool };
        }
    }
}
