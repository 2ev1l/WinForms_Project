using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Collections
{
    internal class ToolTypes : ImportCollection
    {
        public override string Name => "Тип инструмента";
        public override object DefaultValue => Operation.Tools[0];
        protected override object GetData()
        {
            return Operation.Tools;
        }
        public ToolTypes(Operation operation) : base(operation) { }
    }
}
