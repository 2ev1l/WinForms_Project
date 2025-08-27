using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Universal
{
    public class CustomMath
    {
        /// <summary>
        /// Уменьшение точности
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ConvertToFloat(double value) => System.Convert.ToSingle(value);
        /// <summary>
        /// Преобразование строки в число
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ConvertToFloat(string value) => ConvertToFloat(System.Convert.ToDouble(value.Replace(".", ",")));
    }
}
