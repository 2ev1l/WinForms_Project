using ProcessingTimeCalc.Operations.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProcessingTimeCalc.Operations.Collections.RemoveCollection;

namespace ProcessingTimeCalc.Operations.Parameters
{
    internal abstract class RemoveAmountCollection : ParameterCollection
    {
        public override string UnitsName
        {
            get
            {
                if (Collection == null) return "";
                if (Collection.CurrentValue == null) return "";
                return ((RemoveInfo)Collection.CurrentValue).UnitsName;
            }
        }
    }
}
