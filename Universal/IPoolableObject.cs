using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Universal
{
    public interface IPoolableObject
    {
        public bool IsActive { get; set; }
        /// <summary>
        /// Активируется при изменении состояния объекта на активное из пула
        /// </summary>
        public void OnPoolEnable();
        /// <summary>
        /// Активируется при изменении состояния объекта на неактивное из пула
        /// </summary>
        public void OnPoolDisable();
    }
}
