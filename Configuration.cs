using ProcessingTimeCalc.Processing;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProcessingTimeCalc
{
    internal class Configuration
    {
        private const string FILE_NAME = "config.json";
        public static Configuration Instance
        {
            get
            {
                if (!Exist()) instance = Save(new());
                else instance = Load();
                return instance!;
            }
        }
        private static Configuration? instance = null;
        public Files FilesData { get; set; } = new();
        public Processing ProcessingData { get; set; } = new();

        public UI UIData => _uiData;
        private UI _uiData = new();

        [DataMember]
        private string _ui1Data = "abasdcsf";
        public string _ui2Data = "fasfs1";


        private static readonly JsonSerializerOptions options = new JsonSerializerOptions() 
        { 
            IncludeFields = true, 
            WriteIndented = true 
        };
        private static bool Exist()
        {
            return File.Exists(GetFilePath());
        }
        private static Configuration? Load()
        {
            string filePath = GetFilePath();
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Configuration>(json, options);
        }
        public static Configuration Save(Configuration configuration)
        {
            string filePath = GetFilePath();

            string json = JsonSerializer.Serialize(configuration, options);
            File.WriteAllText(filePath, json);
            return configuration;
        }
        private static string GetFilePath() => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILE_NAME);

        [Serializable]
        internal class UI
        {
            /// <summary>
            /// Значение, примеяемое ко всем полям при добавлении операции 
            /// </summary>
            public int DefaultInputValue { get; set; } = 1;
        }
        [Serializable]
        internal class Processing
        {
            /// <summary>
            /// Данные о режимах обработки
            /// </summary>
            public List<ProcessingMode> ProcessingModes { get; set; } = new()
            {
                new("Чистовая обработка", "CHIST"),
                new("Черновая обработка", "CHERN"),
                new("Сверление", "DRILL"),
            };
            /// <summary>
            /// Данные о материалах
            /// </summary>
            public List<Material> Materials { get; set; } = new()
            {
                new("Алюминий", "ALUM"),
                new("Сталь", "STEEL"),
            };
            /// <summary>
            /// Данные о типах инструментов
            /// </summary>
            public Tools ToolsData { get; set; } = new();

            internal class Tools
            {
                public ToolType MilingTool { get; set; } = new("Фреза", "freza");
                public ToolType DrillTool { get; set; } = new("Сверло", "sverlo");
                public ToolType CountersinkTool { get; set; } = new("Зенковка", "zenkovka");
                public ToolType MarkTool { get; set; } = new("Метчик", "metchik");
                public ToolType CenteringTool { get; set; } = new("Центровка", "centrovka");
                public ToolType ReamerTool { get; set; } = new("Развертка", "razvertka");
                public ToolType ThreadMillingTool { get; set; } = new("Резьбофрезеровка", "rezbofreza");

                public float MarkingConst { get; set; } = 80;
                public float CenteringConst { get; set; } = 30f;
                public float ThreadMilingConst { get; set; } = 80f;
            }
        }

        [Serializable]
        internal class Files
        {
            public string DefaultPDFPath { get; set; } = "C:\\";
            public string DefaultPDFName { get; set; } = "ProcessTime_";
            public string DefaultCSVPath { get; set; } = "C:\\";
            public string DefaultCSVName { get; set; } = "tool_database.csv";
            /// <summary>
            /// Пропускать ли первую строчку при чтении данных
            /// </summary>
            public bool SkipFirstLineCSV { get; set; } = true;
        }
    }
}
