using ProcessingTimeCalc.Universal;

namespace ProcessingTimeCalc.Processing
{
    /// <summary>
    /// Данные об обработке
    /// </summary>
    public class ProcessingInfo
    {
        public string ToolName { get; }
        public string ProcessMode { get; }
        public float PitchPerMinute { get; }
        public string Material { get; }
        public string ToolType { get; }

        /// <summary>
        /// Получить диаметр из названия инструмента
        /// </summary>
        /// <returns>Диаметр</returns>
        public float GetDiameter() => GetDiameter(ToolName);
        /// <summary>
        /// Получить диаметр из названия инструмента
        /// </summary>
        /// <param name="toolName">Название инструмента</param>
        /// <returns>Диаметр</returns>
        public static float GetDiameter(string toolName)
        {
            int dPos = toolName.IndexOf("D");
            if (dPos == -1) return 0;
            int _Pos = toolName.IndexOf("_", dPos);
            int length = toolName.Length;
            int startNumberIndex = dPos + 1;
            int endNumberIndex = _Pos <= length && _Pos > -1 ? _Pos : length;
            return CustomMath.ConvertToFloat(toolName.Substring(startNumberIndex, endNumberIndex - startNumberIndex));
        }
        public ProcessingInfo(string toolName, string processMode, float pitchPerMinute, string material, string toolType)
        {
            ToolName = toolName;
            ProcessMode = processMode;
            PitchPerMinute = pitchPerMinute;
            Material = material;
            ToolType = toolType;
        }
    }

}
