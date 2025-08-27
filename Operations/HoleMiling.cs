using ProcessingTimeCalc.Operations.Parameters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations
{
    internal class HoleMiling : Miling
    {
        public override string Name => "Фрезерование отверстий";
        public override float CalculateTime()
        {
            float pitchPerMinute = Parameters[0].Value;
            float d = Parameters[1].Value;
            float h = Parameters[2].Value;
            float l = Convert.ToSingle(d * Math.PI);
            int zMoves = GetMoves((RemoveAmountCollection)Parameters[3], h);
            int xMoves = GetMoves((RemoveAmountCollection)Parameters[4], l);
            float duplicates = Parameters[5].Value;
            float processingLength = 0;
            if (ProcessMode!.Equals(Configuration.Instance.ProcessingData.ProcessingModes[0].CSVName))
                processingLength = l * xMoves + l * zMoves; //CHIST (1 wall)
            else
                processingLength = l * zMoves * xMoves; //CHERN
            return CalculateTimeByBaseParameters(processingLength, pitchPerMinute) * duplicates;
        }

        protected override List<Parameter> GetParameters() => new()
            {
                new PitchPerMinute(),           //0
                new WorkableDiameter(),         //1
                new WorkableHeight(),           //2
                new RemoveAmountZCollection(),  //3
                new RemoveAmountXCollection(),  //4
                new DuplicateAmount(1),         //5
            };
    }
}
