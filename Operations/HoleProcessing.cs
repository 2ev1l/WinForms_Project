using ProcessingTimeCalc.Operations.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations
{
    internal abstract class HoleProcessing : Operation
    {
        public override float CalculateTime()
        {
            return CalculateTimeByBaseParameters(Parameters[1].Value, Parameters[0].Value) * Parameters[2].Value;
        }
        protected override List<Parameter> GetParameters() => new()
        {
            new PitchPerMinute(),
            new WorkableLength(),
            new DuplicateAmount(1),
        };
    }
}
