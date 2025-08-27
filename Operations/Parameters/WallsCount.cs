using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Parameters
{
    internal class WallsCount : Parameter
    {
        private static readonly int maxWallsCount = 3;
        private static readonly int minWallsCount = 0;
        public override string Name => "Кол-во стенок";
        public override string UnitsName => "ед.";

        public override string GetCorrectInputText()
        {
            if (Value % 1 != 0) return "Значение должно быть целочисленным.";
            if (Value > maxWallsCount) return "Значение должно быть меньше 3.";
            if (Value < minWallsCount) return "Значение должно быть больше 0.";
            return "Не числовое значение";
        }
        protected override bool ValidateInput(float input)
        {
            if (Value % 1 != 0) return false;
            if (input > maxWallsCount) return false;
            if (input < minWallsCount) return false;
            return true;
        }
    }
}
