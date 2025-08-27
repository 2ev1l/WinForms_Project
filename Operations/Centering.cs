using ProcessingTimeCalc.Operations.Parameters;
using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations
{
    internal class Centering : HoleProcessing
    {
        public override string Name => "Центровка";
        protected override List<ToolType> GetTools()
        {
            var toolsData = Configuration.Instance.ProcessingData.ToolsData;
            return new() { toolsData.CenteringTool };
        }
        protected override List<Parameter> GetParameters() => new()
        {
            new PitchPerMinute(),
            new WorkableLength(Configuration.Instance.ProcessingData.ToolsData.CenteringConst),
            new DuplicateAmount(1),
        };
    }
}
