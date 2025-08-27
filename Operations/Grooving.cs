using ProcessingTimeCalc.Operations.Parameters;
using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations
{
    internal class Grooving : Miling
    {
        public override string Name => "Фрезерование";
        public override float CalculateTime()
        {
            float pitchPerMinute = Parameters[0].Value;
            float l = Parameters[1].Value;
            float w = Parameters[2].Value;
            float h = Parameters[3].Value;
            int zMoves = GetMoves((RemoveAmountCollection)Parameters[4], h);
            int xMoves = GetMoves((RemoveAmountCollection)Parameters[5], w);
            int wallsCount = (int)(Parameters[6].Value);
            float duplicates = Parameters[7].Value;
            float processingLength = 0;
            if (ProcessMode!.Equals(Configuration.Instance.ProcessingData.ProcessingModes[0].CSVName))
                processingLength = l * xMoves + l * zMoves * wallsCount; //CHIST
            else
                processingLength = l * zMoves * xMoves; //CHERN
            return CalculateTimeByBaseParameters(processingLength, pitchPerMinute) * duplicates;
        }

        protected override List<Parameter> GetParameters() => new()
            {
                new PitchPerMinute(),   //0
                new WorkableLength(),   //1
                new WorkableWidth(),    //2
                new WorkableHeight(),   //3
                new RemoveAmountZCollection(), //4
                new RemoveAmountXCollection(), //5
                new WallsCount(), //6
                new DuplicateAmount(1),  //7
            };
    }
}
