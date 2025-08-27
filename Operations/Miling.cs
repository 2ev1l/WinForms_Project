using ProcessingTimeCalc.Operations.Collections;
using ProcessingTimeCalc.Operations.Parameters;
using ProcessingTimeCalc.Processing;
using ProcessingTimeCalc.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProcessingTimeCalc.Operations.Collections.RemoveCollection;

namespace ProcessingTimeCalc.Operations
{
    internal abstract class Miling : Operation
    {
        protected string? CurrentTool { get; private set; }
        protected string? ProcessMode { get; private set; }
        public override void OnProcessingInfoChanged(ProcessingInfo? info)
        {
            base.OnProcessingInfoChanged(info);
            if (info != null)
            {
                CurrentTool = info.ToolName;
                ProcessMode = info.ProcessMode;
            }
            else
            {
                CurrentTool = null;
                ProcessMode = null;
            }
        }
        protected int GetMoves(RemoveAmountCollection removeAmountCollection, float width)
        {
            RemoveInfo info = (RemoveInfo)(removeAmountCollection.Collection!.CurrentValue!);
            float value = removeAmountCollection.Value;
            float moveCount = (info.Removes) switch
            {
                Removes.Moves => (value),
                Removes.MM => width / value,
                Removes.D => width / (ProcessingInfo.GetDiameter(CurrentTool!) * (value) / 100f),
                _ => throw new System.NotImplementedException()
            };
            return (int)MathF.Ceiling(moveCount);
        }
        public override float CalculateTime()
        {
            float pitchPerMinute = Parameters[0].Value;
            float processingLength = Parameters[1].Value;
            float duplicates = Parameters[2].Value;
            return CalculateTimeByBaseParameters(processingLength, pitchPerMinute) * duplicates;
        }
        protected override List<Parameter> GetParameters() => new()
            {
                new PitchPerMinute(),
                new WorkableLength(),
                new DuplicateAmount(1)
            };
        protected override List<ToolType> GetTools()
        {
            var toolsData = Configuration.Instance.ProcessingData.ToolsData;
            return new() { toolsData.MilingTool };
        }
    }
}
