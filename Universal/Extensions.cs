using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Universal
{
    public class Extensions
    {
        /// <summary>
        /// Секунды в машино-часы
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string ToMachineTime(float seconds)
        {
            float precision = 10;
            float ceiled = MathF.Ceiling(seconds / 3600 * precision);
            return $"{ceiled / precision:F1}";
        }
        /// <summary>
        /// Секунды в любой формат
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToTime(float seconds, string format)
        {
            return string.Format("{0}", new DateTime(TimeSpan.FromSeconds(seconds).Ticks).ToString(format));
        }
    }
}
