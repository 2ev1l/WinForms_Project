using ProcessingTimeCalc.Operations.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Parameters
{
    internal class RemoveAmountZCollection : RemoveAmountCollection
    {
        public override string Name => "Съем в глубину";
        protected override Collection CreateCollection(Operation operation)
        {
            return new RemoveCollectionZ(operation);
        }
    }
}
