using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Processing
{
    /// <summary>
    /// Ячейка, импортируемая из CSV
    /// </summary>
    public class ImportElement
    {
        /// <summary>
        /// Отображаемое имя в интерфейсе
        /// </summary>
        public string UIName { get; set; }
        /// <summary>
        /// Название в файле
        /// </summary>
        public string CSVName { get; set; }

        public ImportElement(string UIName, string CSVName)
        {
            this.UIName = UIName;
            this.CSVName = CSVName;
        }
    }
}
