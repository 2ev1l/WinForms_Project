using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Collections
{
    internal class ToolNames : ImportCollection
    {
        public override string Name => "Инструмент";
        public override object DefaultValue
        {
            get
            {
                try
                {
                    _ = DataSource;
                    return tools![0];
                }
                catch
                {
                    return 0;
                }
            }
        }
        private List<ToolModel>? tools = null;
        protected override object GetData()
        {
            var strs = GetExistCollectionsByToolType(x => x.ToolName);
            tools = strs.Select(x => new ToolModel(x)).ToList();
            return tools;
        }
        public ToolNames(Operation operation) : base(operation) { }
    }
}
