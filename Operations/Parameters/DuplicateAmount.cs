using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Parameters
{
    internal class DuplicateAmount : Parameter
    {
        public override string Name => "Количество операций";
        public override string UnitsName => "ед.";
        public override string GetCorrectInputText()
        {
            if (Value % 1 != 0)
                return "Значение должно быть целочисленным.";
            return base.GetCorrectInputText();
        }
        protected override bool ValidateInput(float input)
        {
            if (input % 1 != 0)
                return false;
            return base.ValidateInput(input);
        }
        public DuplicateAmount() { }
        public DuplicateAmount(float defaultValue) : base(defaultValue) { }
    }
}
