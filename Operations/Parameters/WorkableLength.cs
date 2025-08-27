using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Parameters
{
    internal class WorkableLength : Parameter
    {
        public override string Name => "Обрабатываемая длина";
        public override string UnitsName => "мм";

        public WorkableLength() { }
        public WorkableLength(float defaultValue) : base(defaultValue) { }
    }
}
