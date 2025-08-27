using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Parameters
{
    internal class TurnoverAmount : Parameter
    {
        public override string Name => "Количество оборотов";
        public override string UnitsName => "ед.";

        public TurnoverAmount() { }
        public TurnoverAmount(float defaultValue) : base(defaultValue) { }
    }
}
