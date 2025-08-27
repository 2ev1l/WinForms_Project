using ProcessingTimeCalc.Universal;

namespace ProcessingTimeCalc.Processing
{
    internal class ToolsData
    {
        public static ToolsData Instance
        {
            get
            {
                instance ??= new();
                return instance!;
            }
        }
        private static ToolsData? instance = null;

        /// <summary>
        /// Импортированные данные об обработке
        /// </summary>
        public IReadOnlyList<ProcessingInfo>? ProcessingInfos
        {
            get
            {
                return processingInfos;
            }
        }
        private List<ProcessingInfo>? processingInfos = null;
        public bool IsDataLoaded => isDataLoaded;
        private bool isDataLoaded = false;

        public ProcessingInfo? FindInfo(string toolName, string toolType, string material, string processMode)
        {
            return processingInfos!.Find(x => x.ToolName.Equals(toolName) && x.ToolType.Equals(toolType) && x.Material.Equals(material) && x.ProcessMode.Equals(processMode));
        }
        /// <summary>
        /// Загрузить данные по параметрам конфигурации
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public bool TryLoadDataFromConfiguration()
        {
            if (isDataLoaded) return false;
            isDataLoaded = TryLoadCSVFrom(Path.Combine(Configuration.Instance.FilesData.DefaultCSVPath, Configuration.Instance.FilesData.DefaultCSVName), out processingInfos);
            return isDataLoaded;
        }
        /// <summary>
        /// Загрузить данные путем выбора файла
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public bool TryLoadData()
        {
            if (isDataLoaded) return false;
            isDataLoaded = TryLoadCSV(out processingInfos);
            return isDataLoaded;
        }
        private bool TryLoadCSV(out List<ProcessingInfo>? infos)
        {
            infos = CSVReader.Read(Configuration.Instance.FilesData.SkipFirstLineCSV, CreateNewTool);
            return infos != null;
        }
        private bool TryLoadCSVFrom(string dir, out List<ProcessingInfo>? infos)
        {
            infos = CSVReader.ReadFrom(dir, Configuration.Instance.FilesData.SkipFirstLineCSV, CreateNewTool);
            return infos != null;
        }
        private ProcessingInfo CreateNewTool(string[] x)
        {
            return new ProcessingInfo(x[0], x[1], CustomMath.ConvertToFloat(x[2]), x[3], x[4]);
        }
    }
}
