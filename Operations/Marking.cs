using ProcessingTimeCalc.Operations.Parameters;
using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations
{
    internal class Marking : HoleProcessing
    {
        public override string Name => "Метчик";

        public override float CalculateTime()
        {
            return CalculateTimeByBaseParameters(Parameters[1].Value, Parameters[0].Value * Parameters[2].Value) * Parameters[3].Value;
        }
        protected override List<Parameter> GetParameters() => new()
        {
            new TurnoverPitch(),
            new WorkableLength(),
            new TurnoverAmount(Configuration.Instance.ProcessingData.ToolsData.MarkingConst),
            new DuplicateAmount(1),
        };
        protected override List<ToolType> GetTools()
        {
            var toolsData = Configuration.Instance.ProcessingData.ToolsData;
            return new() { toolsData.MarkTool };
        }
    }
}
