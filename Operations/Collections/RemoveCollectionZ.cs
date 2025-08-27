using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Collections
{
    internal class RemoveCollectionZ : RemoveCollection
    {
        public override string Name => "Съем в глубину";
        public RemoveCollectionZ(Operation operation) : base(operation) { }
    }
}
