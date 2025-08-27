using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Collections
{
    internal class ProcessingModes : ImportCollection
    {
        public override string Name => "Обработка";
        public override object DefaultValue
        {
            get
            {
                try
                {
                    _ = DataSource;
                    return modes![0];
                }
                catch
                {
                    return 0;
                }
            }
        }
        private List<ProcessingMode>? modes = null;
        protected override object GetData()
        {
            var strs = GetExistCollectionsByToolType(x => x.ProcessMode);
            modes = Configuration.Instance.ProcessingData.ProcessingModes.Where(x => strs.Contains(x.CSVName)).ToList();
            return modes;
        }
        public ProcessingModes(Operation operation) : base(operation) { }
    }
}
