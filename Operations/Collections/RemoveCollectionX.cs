using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Collections
{
    internal class RemoveCollectionX : RemoveCollection
    {
        public override string Name => "Съем в ширину";
        public RemoveCollectionX(Operation operation) : base(operation) { }
    }
}
