using ProcessingTimeCalc.Operations.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Parameters
{
    internal class RemoveAmountXCollection : RemoveAmountCollection
    {
        public override string Name => "Съем в бок";
        protected override Collection CreateCollection(Operation operation)
        {
            return new RemoveCollectionX(operation);
        }
    }
}
