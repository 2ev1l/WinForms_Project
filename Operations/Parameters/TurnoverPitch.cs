using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Parameters
{
    internal class TurnoverPitch : Parameter
    {
        public override string Name => "Подача на оборот";
        public override string UnitsName => "мм/об";
        public override bool ReadOnly => true;
        
        public override void OnProcessingInfoChanged(ProcessingInfo? info)
        {
            base.OnProcessingInfoChanged(info);
            if (info != null)
            {
                TrySaveInput(info.PitchPerMinute.ToString());
            }
            else
            {
                TrySaveInput(Configuration.Instance.UIData.DefaultInputValue.ToString());
            }
        }
    }
}
