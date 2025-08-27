using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Universal
{
    internal static class CSVReader
    {
        /// <summary>
        /// Загрузить данные из файла (выбор пути)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="skipFirstLine">Пропускать ли первую строку</param>
        /// <param name="createClass">Создание нового экземляра класса, используя данные из строки</param>
        /// <returns></returns>
        public static List<T>? Read<T>(bool skipFirstLine, Func<string[], T> createClass) 
            where T : class
        {
            if (!TryChooseDirectory(out OpenFileDialog dialog)) return null;
            return ReadFrom(dialog.FileName, skipFirstLine, createClass);
        }
        /// <summary>
        /// Загрузить данные из файла
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dir">Путь</param>
        /// <param name="skipFirstLine">Пропускать ли первую строку</param>
        /// <param name="createClass">Создание нового экземляра класса, используя данные из строки</param>
        /// <returns></returns>
        public static List<T>? ReadFrom<T>(string dir, bool skipFirstLine, Func<string[], T> createClass) where T : class
        {
            if (!File.Exists(dir)) return null;
            using TextFieldParser csvParser = new(dir);
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;

            List<T> result = new();
            if (skipFirstLine) csvParser.ReadLine();
            while (!csvParser.EndOfData)
            {
                string[] fields = csvParser.ReadFields()!;
                result.Add(createClass.Invoke(fields));
            }
            csvParser.Close();
            return result;
        }
        private static bool TryChooseDirectory(out OpenFileDialog dialogMenu) => ChooseDirectory(out dialogMenu) == DialogResult.OK;
        private static DialogResult ChooseDirectory(out OpenFileDialog dialogMenu)
        {
            dialogMenu = new OpenFileDialog
            {
                InitialDirectory = Configuration.Instance.FilesData.DefaultCSVPath,
                Filter = "(*.csv)|*.csv",
                AddExtension = true,
                DefaultExt = "csv",
                RestoreDirectory = true
            };
            return dialogMenu.ShowDialog();
        }
    }
}
