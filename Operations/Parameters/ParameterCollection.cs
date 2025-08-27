using ProcessingTimeCalc.Operations.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Parameters
{
    /// <summary>
    /// Комбинация параметра и коллекции. 
    /// Выбор из коллекции влияет на значение параметра.
    /// </summary>
    internal abstract class ParameterCollection : Parameter
    {
        public Collection? Collection => collection;
        private Collection? collection = null;
        public void Initialize(Operation op)
        {
            collection = CreateCollection(op);
        }
        /// <summary>
        /// Создать новую коллекцию
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        protected abstract Collection CreateCollection(Operation operation);
    }
}
