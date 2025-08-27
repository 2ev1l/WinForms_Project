using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Collections
{
    internal abstract class RemoveCollection : Collection
    {
        public override string DisplayMember => "UIName";
        public override object DefaultValue => Info[0];
        private List<RemoveInfo> Info
        {
            get
            {
                if (info == null)
                    _ = base.DataSource;
                return info!;
            }
        }
        private List<RemoveInfo>? info;

        protected override object GetData()
        {
            info = new List<RemoveInfo>() { new(Removes.Moves, "Проходы", "Раз"), new(Removes.MM, "мм", "мм"), new(Removes.D, "% Диаметра", "%") };
            return info;
        }

        protected RemoveCollection(Operation operation) : base(operation) { }
        public readonly struct RemoveInfo
        {
            public Removes Removes { get; }
            public string UIName { get; }
            public string UnitsName { get; }
            public RemoveInfo(Removes Removes, string UIName, string UnitsName)
            {
                this.Removes = Removes;
                this.UIName = UIName;
                this.UnitsName = UnitsName;
            }
        }
        public enum Removes
        {
            MM,
            D,
            Moves
        }
    }
}
