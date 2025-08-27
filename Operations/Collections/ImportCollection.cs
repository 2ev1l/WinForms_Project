using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Collections
{
    /// <summary>
    /// Коллекция, использующая импортированные данные об обработке
    /// </summary>
    public abstract class ImportCollection : Collection
    {
        public override string DisplayMember => "UIName";
        protected IEnumerable<string> GetExistCollectionsByToolType(Func<ProcessingInfo, string> getData)
        {
            IEnumerable<string> toolTypes = Operation.Tools.Select(x => x.CSVName);
            var strs = ToolsData.Instance.ProcessingInfos!
                .Where(x => toolTypes.Contains(x.ToolType))
                .Select(getData)
                .Distinct();
            return strs;
        }
        protected ImportCollection(Operation operation) : base(operation) { }

    }
}
