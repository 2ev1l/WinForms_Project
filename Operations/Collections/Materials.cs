using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Collections
{
    internal class Materials : ImportCollection
    {
        public override string Name => "Материал";
        public override object DefaultValue
        {
            get
            {
                try
                {
                    _ = DataSource;
                    return materials![0];
                }
                catch
                {
                    return 0;
                }
            }
        }
        private List<Material>? materials = null;
        protected override object GetData()
        {
            var strs = GetExistCollectionsByToolType(x => x.Material);
            materials = Configuration.Instance.ProcessingData.Materials.Where(x => strs.Contains(x.CSVName)).ToList();
            return materials;
        }
        public Materials(Operation operation) : base(operation) { }
    }
}
